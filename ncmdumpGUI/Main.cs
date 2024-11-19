using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ncmdumpGUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        FileInfo configFileInfo;

        private void Main_Load(object sender, EventArgs e)
        {
            StreamReader configFileReader = null;
            try
            {
                configFileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "config");
                if (configFileInfo.Exists)
                {
                    configFileReader = configFileInfo.OpenText();
                    while(!configFileReader.EndOfStream)
                    {
                        String line = configFileReader.ReadLine().Trim();
                        if (String.IsNullOrEmpty(line) || !line.Contains("="))
                        {
                            continue;
                        }
                        String[] config = line.Split('=');
                        String key = config[0];
                        String value = config[1];
                        if (key == "ncmFolderPath")
                        {
                        }
                        else if (key == "mp3FolderPath")
                        {
                            this.txtMp3FolderPath.Text = value;
                        }
                    }
                    configFileReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            finally
            {
                if (configFileReader != null)
                    configFileReader.Close();
            }
        }

        private void btnSelectNcmFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = "";
            DialogResult dlg = folderBrowserDialog.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                //txtNcmFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
        bool waitSelectMp3Folder = false;
        private void btnSelectMp3Folder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = "";
            DialogResult dlg = folderBrowserDialog.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                txtMp3FolderPath.Text = folderBrowserDialog.SelectedPath;
                if (waitSelectMp3Folder)
                {
                    waitSelectMp3Folder = false;

                    ConvertProc();
                }
            }
        }

        Thread backgroundWork;
        delegate void DelUIThreadOperation();
        DelUIThreadOperation delUIThreadOperation;

        private void btnStart_Click(object sender, EventArgs e)
        {
            backgroundWork = new Thread(ConvertProc);
            backgroundWork.Start();
        }

        private void ConvertProc()
        {
            label_State.Text = "-";
            //ProgressDialogControl progressDialogControl = new ProgressDialogControl();
            IAsyncResult asyncResult;
            try
            {
                //BeginInvoke(progressDialogControl.delProgressDlg, ProgressStatusType.BackgroundWorkStart, "正在转换文件，请稍候......");
                //while (!progressDialogControl.IsProgressDlgHandleCreate)
                //{
                //    Thread.Sleep(100);
                //}

                string mp3FolderPath = "";

                delUIThreadOperation = new DelUIThreadOperation(delegate ()
                {
                    mp3FolderPath = this.txtMp3FolderPath.Text;
                });
                asyncResult = BeginInvoke(delUIThreadOperation);
                EndInvoke(asyncResult);

                StreamWriter configFileWriter = null;
                if (configFileInfo.Exists)
                {
                    File.Delete(configFileInfo.FullName);
                }
                try
                {
                    configFileWriter = configFileInfo.CreateText();
                    configFileWriter.WriteLine("mp3FolderPath=" + mp3FolderPath);
                    configFileWriter.Flush();
                }
                finally
                {
                    if (configFileWriter != null)
                        configFileWriter.Close();
                }

                DirectoryInfo mp3DirctoryInfo = new DirectoryInfo(mp3FolderPath);
                foreach (ListViewItem item in FileListView.Items)
                {
                    var fileInfo = new FileInfo(item.SubItems[1].Text);
                    if (!fileInfo.Exists)
                    {
                        filePathToListItem[fileInfo.FullName].SubItems[2].Text = "文件不存在";
                        continue;
                    }
                    if(filePathToListItem[fileInfo.FullName].SubItems[2].Text == "转换完成")
                    {
                        continue;
                    }
                    try
                    {
                        //BeginInvoke(progressDialogControl.delProgressDlg, ProgressStatusType.BackgroundWorkUpdate, "转换：" + fileInfo.Name);
                        NeteaseCrypto neteaseFile = new NeteaseCrypto(fileInfo);
                        neteaseFile.Dump(mp3FolderPath);
                        filePathToListItem[fileInfo.FullName].SubItems[2].Text = "转换完成";
                    }
                    catch(Exception ex)
                    {
                        filePathToListItem[fileInfo.FullName].SubItems[2].Text = "转换失败";
                    }
                }

                delUIThreadOperation = new DelUIThreadOperation(delegate ()
                {
                    MessageBox.Show("转换完成！","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
                asyncResult = BeginInvoke(delUIThreadOperation);
                EndInvoke(asyncResult);
            }
            catch (Exception ex)
            {
                delUIThreadOperation = new DelUIThreadOperation(delegate ()
                {
                    MessageBox.Show("转换失败！" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                asyncResult = BeginInvoke(delUIThreadOperation);
                EndInvoke(asyncResult);
            }
            finally
            {
                //if (progressDialogControl.IsProgressDlgAlive)
                //{
                //    asyncResult = BeginInvoke(progressDialogControl.delProgressDlg, ProgressStatusType.BackgroundWorkStop, "");
                //    EndInvoke(asyncResult);
                //}
            }
        }
        private Dictionary<string, ListViewItem> filePathToListItem = new Dictionary<string, ListViewItem>();
        private void FileListView_DragDrop(object sender, DragEventArgs e)
        {
            var dropData = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            foreach(string path in dropData)
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists && file.Extension.ToLower() == ".ncm")
                {
                    //处理重复添加
                    if (filePathToListItem.ContainsKey(file.FullName))
                    {
                        continue;
                    }
                    //在列表中添加项
                    var item = new ListViewItem(new string[] { file.Name, file.FullName, "" });
                    FileListView.Items.Add(item);
                    filePathToListItem.Add(file.FullName, item);
                }
            }
            if (Directory.Exists(txtMp3FolderPath.Text))
            {
                ConvertProc();
            }
            else
            {
                waitSelectMp3Folder = true;
                label_State.Text = "请选择输出目录";
            }
        }

        private void FileListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btnCleanList_Click(object sender, EventArgs e)
        {
            backgroundWork?.Abort();
            FileListView.Items.Clear();
            filePathToListItem.Clear();
        }
    }
}
