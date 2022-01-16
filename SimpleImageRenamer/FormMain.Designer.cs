
namespace SimpleImageRenamer
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.buttonAddDirectory = new System.Windows.Forms.Button();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.columnHeaderDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStartRenaming = new System.Windows.Forms.Button();
            this.radioButtonFormatDefault = new System.Windows.Forms.RadioButton();
            this.radioButtonFormatCustom = new System.Windows.Forms.RadioButton();
            this.textBoxFormatCustom = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerImportImages = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRenameImages = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(728, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemHelp.Text = "Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.Location = new System.Drawing.Point(12, 27);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(110, 23);
            this.buttonAddFiles.TabIndex = 1;
            this.buttonAddFiles.Text = "Add Files";
            this.buttonAddFiles.UseVisualStyleBackColor = true;
            this.buttonAddFiles.Click += new System.EventHandler(this.buttonAddFiles_Click);
            // 
            // buttonAddDirectory
            // 
            this.buttonAddDirectory.Location = new System.Drawing.Point(128, 27);
            this.buttonAddDirectory.Name = "buttonAddDirectory";
            this.buttonAddDirectory.Size = new System.Drawing.Size(110, 23);
            this.buttonAddDirectory.TabIndex = 2;
            this.buttonAddDirectory.Text = "Add Directory";
            this.buttonAddDirectory.UseVisualStyleBackColor = true;
            this.buttonAddDirectory.Click += new System.EventHandler(this.buttonAddDirectory_Click);
            // 
            // listViewImages
            // 
            this.listViewImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDirectory,
            this.columnHeaderOldName,
            this.columnHeaderNewName});
            this.listViewImages.FullRowSelect = true;
            this.listViewImages.HideSelection = false;
            this.listViewImages.Location = new System.Drawing.Point(12, 82);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(704, 213);
            this.listViewImages.TabIndex = 6;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDirectory
            // 
            this.columnHeaderDirectory.Text = "Directory";
            this.columnHeaderDirectory.Width = 300;
            // 
            // columnHeaderOldName
            // 
            this.columnHeaderOldName.Text = "Old Name";
            this.columnHeaderOldName.Width = 200;
            // 
            // columnHeaderNewName
            // 
            this.columnHeaderNewName.Text = "New Name";
            this.columnHeaderNewName.Width = 200;
            // 
            // buttonStartRenaming
            // 
            this.buttonStartRenaming.Location = new System.Drawing.Point(12, 301);
            this.buttonStartRenaming.Name = "buttonStartRenaming";
            this.buttonStartRenaming.Size = new System.Drawing.Size(110, 23);
            this.buttonStartRenaming.TabIndex = 7;
            this.buttonStartRenaming.Text = "Rename {n} Files";
            this.buttonStartRenaming.UseVisualStyleBackColor = true;
            this.buttonStartRenaming.Click += new System.EventHandler(this.buttonStartRenaming_Click);
            // 
            // radioButtonFormatDefault
            // 
            this.radioButtonFormatDefault.AutoSize = true;
            this.radioButtonFormatDefault.Checked = true;
            this.radioButtonFormatDefault.Location = new System.Drawing.Point(12, 58);
            this.radioButtonFormatDefault.Name = "radioButtonFormatDefault";
            this.radioButtonFormatDefault.Size = new System.Drawing.Size(123, 17);
            this.radioButtonFormatDefault.TabIndex = 3;
            this.radioButtonFormatDefault.TabStop = true;
            this.radioButtonFormatDefault.Text = "yyyyMMdd_HHmmss";
            this.radioButtonFormatDefault.UseVisualStyleBackColor = true;
            this.radioButtonFormatDefault.CheckedChanged += new System.EventHandler(this.radioButtonFormat_CheckedChanged);
            // 
            // radioButtonFormatCustom
            // 
            this.radioButtonFormatCustom.AutoSize = true;
            this.radioButtonFormatCustom.Location = new System.Drawing.Point(141, 60);
            this.radioButtonFormatCustom.Name = "radioButtonFormatCustom";
            this.radioButtonFormatCustom.Size = new System.Drawing.Size(14, 13);
            this.radioButtonFormatCustom.TabIndex = 4;
            this.radioButtonFormatCustom.UseVisualStyleBackColor = true;
            this.radioButtonFormatCustom.CheckedChanged += new System.EventHandler(this.radioButtonFormat_CheckedChanged);
            // 
            // textBoxFormatCustom
            // 
            this.textBoxFormatCustom.Location = new System.Drawing.Point(161, 56);
            this.textBoxFormatCustom.Name = "textBoxFormatCustom";
            this.textBoxFormatCustom.Size = new System.Drawing.Size(150, 20);
            this.textBoxFormatCustom.TabIndex = 5;
            this.textBoxFormatCustom.Text = "{yyyyMMdd}_{HHmmss}";
            this.textBoxFormatCustom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFormatCustom_KeyDown);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripProgressBar,
            this.statusStripStatusLabelStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 333);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(728, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusStripProgressBar
            // 
            this.statusStripProgressBar.Name = "statusStripProgressBar";
            this.statusStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // statusStripStatusLabelStatus
            // 
            this.statusStripStatusLabelStatus.Name = "statusStripStatusLabelStatus";
            this.statusStripStatusLabelStatus.Size = new System.Drawing.Size(121, 17);
            this.statusStripStatusLabelStatus.Text = "Renamed {n}/{n} Files";
            // 
            // backgroundWorkerImportImages
            // 
            this.backgroundWorkerImportImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerImportImages_DoWork);
            this.backgroundWorkerImportImages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerImportImages_RunWorkerCompleted);
            // 
            // backgroundWorkerRenameImages
            // 
            this.backgroundWorkerRenameImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRenameImages_DoWork);
            this.backgroundWorkerRenameImages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRenameImages_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 355);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.textBoxFormatCustom);
            this.Controls.Add(this.radioButtonFormatCustom);
            this.Controls.Add(this.radioButtonFormatDefault);
            this.Controls.Add(this.buttonStartRenaming);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.buttonAddDirectory);
            this.Controls.Add(this.buttonAddFiles);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.Button buttonAddDirectory;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.ColumnHeader columnHeaderDirectory;
        private System.Windows.Forms.ColumnHeader columnHeaderOldName;
        private System.Windows.Forms.ColumnHeader columnHeaderNewName;
        private System.Windows.Forms.Button buttonStartRenaming;
        private System.Windows.Forms.RadioButton radioButtonFormatDefault;
        private System.Windows.Forms.RadioButton radioButtonFormatCustom;
        private System.Windows.Forms.TextBox textBoxFormatCustom;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripProgressBar statusStripProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerImportImages;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRenameImages;
    }
}

