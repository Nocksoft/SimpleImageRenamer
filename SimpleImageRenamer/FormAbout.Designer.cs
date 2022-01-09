
namespace SimpleImageRenamer
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelCopyright = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelThirdParty = new System.Windows.Forms.Label();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCopyright.Location = new System.Drawing.Point(14, 360);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(192, 13);
            this.labelCopyright.TabIndex = 6;
            this.labelCopyright.Text = "© 2022 Rafael Nockmann @ Nocksoft";
            this.labelCopyright.Click += new System.EventHandler(this.labelCopyright_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(205, 25);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "SimpleImageRenamer";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(14, 37);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(383, 17);
            this.labelDescription.TabIndex = 8;
            this.labelDescription.Text = "Software to rename photos and videos based on EXIF data.";
            // 
            // labelThirdParty
            // 
            this.labelThirdParty.AutoSize = true;
            this.labelThirdParty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelThirdParty.Location = new System.Drawing.Point(14, 67);
            this.labelThirdParty.Name = "labelThirdParty";
            this.labelThirdParty.Size = new System.Drawing.Size(389, 26);
            this.labelThirdParty.TabIndex = 9;
            this.labelThirdParty.Text = "This Software uses ExifTool 12.38 (https://exiftool.org) to extract time informat" +
    "ion\r\n from photos and videos. ExifTool is released under GNU General Public Lice" +
    "nse.";
            this.labelThirdParty.Click += new System.EventHandler(this.labelThirdParty_Click);
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxLicense.Location = new System.Drawing.Point(17, 115);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.ReadOnly = true;
            this.richTextBoxLicense.Size = new System.Drawing.Size(400, 231);
            this.richTextBoxLicense.TabIndex = 10;
            this.richTextBoxLicense.Text = resources.GetString("richTextBoxLicense.Text");
            this.richTextBoxLicense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxLicense_KeyDown);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 382);
            this.Controls.Add(this.richTextBoxLicense);
            this.Controls.Add(this.labelThirdParty);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAbout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCopyright;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelThirdParty;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
    }
}