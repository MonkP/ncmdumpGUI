namespace ncmdumpGUI
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCleanList = new System.Windows.Forms.Button();
            this.label_State = new System.Windows.Forms.Label();
            this.FileListView = new System.Windows.Forms.ListView();
            this.Col_FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectMp3Folder = new System.Windows.Forms.Button();
            this.txtMp3FolderPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "输出目录：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "将ncm文件转成mp3文件";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCleanList);
            this.groupBox1.Controls.Add(this.label_State);
            this.groupBox1.Controls.Add(this.FileListView);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelectMp3Folder);
            this.groupBox1.Controls.Add(this.txtMp3FolderPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 384);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCleanList
            // 
            this.btnCleanList.Location = new System.Drawing.Point(647, 11);
            this.btnCleanList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCleanList.Name = "btnCleanList";
            this.btnCleanList.Size = new System.Drawing.Size(75, 20);
            this.btnCleanList.TabIndex = 6;
            this.btnCleanList.Text = "清空列表";
            this.btnCleanList.UseVisualStyleBackColor = true;
            this.btnCleanList.Click += new System.EventHandler(this.btnCleanList_Click);
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_State.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_State.Location = new System.Drawing.Point(8, 331);
            this.label_State.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(15, 15);
            this.label_State.TabIndex = 5;
            this.label_State.Text = "-";
            // 
            // FileListView
            // 
            this.FileListView.AllowDrop = true;
            this.FileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_FileName,
            this.Col_Path,
            this.Col_Status});
            this.FileListView.HideSelection = false;
            this.FileListView.Location = new System.Drawing.Point(8, 35);
            this.FileListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(715, 294);
            this.FileListView.TabIndex = 2;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.View = System.Windows.Forms.View.Details;
            this.FileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListView_DragDrop);
            this.FileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileListView_DragEnter);
            // 
            // Col_FileName
            // 
            this.Col_FileName.Text = "文件名";
            this.Col_FileName.Width = 171;
            // 
            // Col_Path
            // 
            this.Col_Path.Text = "完整路径";
            this.Col_Path.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Col_Path.Width = 479;
            // 
            // Col_Status
            // 
            this.Col_Status.Text = "状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "拖放要处理的文件";
            // 
            // btnSelectMp3Folder
            // 
            this.btnSelectMp3Folder.Location = new System.Drawing.Point(647, 352);
            this.btnSelectMp3Folder.Name = "btnSelectMp3Folder";
            this.btnSelectMp3Folder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMp3Folder.TabIndex = 4;
            this.btnSelectMp3Folder.Text = "选择目录";
            this.btnSelectMp3Folder.UseVisualStyleBackColor = true;
            this.btnSelectMp3Folder.Click += new System.EventHandler(this.btnSelectMp3Folder_Click);
            // 
            // txtMp3FolderPath
            // 
            this.txtMp3FolderPath.Location = new System.Drawing.Point(74, 355);
            this.txtMp3FolderPath.Name = "txtMp3FolderPath";
            this.txtMp3FolderPath.Size = new System.Drawing.Size(567, 21);
            this.txtMp3FolderPath.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 441);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(768, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(768, 480);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ncmdumpGUI by kpali v1.2";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectMp3Folder;
        private System.Windows.Forms.TextBox txtMp3FolderPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.ListView FileListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCleanList;
        internal System.Windows.Forms.ColumnHeader Col_FileName;
        private System.Windows.Forms.ColumnHeader Col_Path;
        private System.Windows.Forms.ColumnHeader Col_Status;
    }
}

