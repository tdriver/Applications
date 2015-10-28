namespace PhotoImporter
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VideoFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.PictureFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tbImportPicsTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbImportPicsFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbImportVideosTo = new System.Windows.Forms.TextBox();
            this.btnImportPicturesFrom = new System.Windows.Forms.Button();
            this.btnImportPicturesTo = new System.Windows.Forms.Button();
            this.btnImportVideosTo = new System.Windows.Forms.Button();
            this.ImportPicturesFromFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // VideoFolder
            // 
            this.VideoFolder.SelectedPath = "F:\\Videos\\By Date";
            // 
            // PictureFolder
            // 
            this.PictureFolder.SelectedPath = "d:\\pictures\\By Date";
            // 
            // tbImportPicsTo
            // 
            this.tbImportPicsTo.Location = new System.Drawing.Point(12, 88);
            this.tbImportPicsTo.Name = "tbImportPicsTo";
            this.tbImportPicsTo.Size = new System.Drawing.Size(212, 20);
            this.tbImportPicsTo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Import Pictures to...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Import Pictures from...";
            // 
            // tbImportPicsFrom
            // 
            this.tbImportPicsFrom.Location = new System.Drawing.Point(12, 25);
            this.tbImportPicsFrom.Name = "tbImportPicsFrom";
            this.tbImportPicsFrom.Size = new System.Drawing.Size(212, 20);
            this.tbImportPicsFrom.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Import Videos to...";
            // 
            // tbImportVideosTo
            // 
            this.tbImportVideosTo.Location = new System.Drawing.Point(12, 139);
            this.tbImportVideosTo.Name = "tbImportVideosTo";
            this.tbImportVideosTo.Size = new System.Drawing.Size(212, 20);
            this.tbImportVideosTo.TabIndex = 6;
            // 
            // btnImportPicturesFrom
            // 
            this.btnImportPicturesFrom.Location = new System.Drawing.Point(230, 25);
            this.btnImportPicturesFrom.Name = "btnImportPicturesFrom";
            this.btnImportPicturesFrom.Size = new System.Drawing.Size(33, 23);
            this.btnImportPicturesFrom.TabIndex = 8;
            this.btnImportPicturesFrom.Text = "...";
            this.btnImportPicturesFrom.UseVisualStyleBackColor = true;
            this.btnImportPicturesFrom.Click += new System.EventHandler(this.btnImportPicturesFrom_Click);
            // 
            // btnImportPicturesTo
            // 
            this.btnImportPicturesTo.Location = new System.Drawing.Point(230, 85);
            this.btnImportPicturesTo.Name = "btnImportPicturesTo";
            this.btnImportPicturesTo.Size = new System.Drawing.Size(33, 23);
            this.btnImportPicturesTo.TabIndex = 9;
            this.btnImportPicturesTo.Text = "...";
            this.btnImportPicturesTo.UseVisualStyleBackColor = true;
            this.btnImportPicturesTo.Click += new System.EventHandler(this.btnImportPicturesTo_Click);
            // 
            // btnImportVideosTo
            // 
            this.btnImportVideosTo.Location = new System.Drawing.Point(230, 136);
            this.btnImportVideosTo.Name = "btnImportVideosTo";
            this.btnImportVideosTo.Size = new System.Drawing.Size(33, 23);
            this.btnImportVideosTo.TabIndex = 10;
            this.btnImportVideosTo.Text = "...";
            this.btnImportVideosTo.UseVisualStyleBackColor = true;
            this.btnImportVideosTo.Click += new System.EventHandler(this.btnImportVideosTo_Click);
            // 
            // ImportPicturesFromFolder
            // 
            this.ImportPicturesFromFolder.SelectedPath = "d:\\Pictures\\ToImport";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnImportVideosTo);
            this.Controls.Add(this.btnImportPicturesTo);
            this.Controls.Add(this.btnImportPicturesFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbImportVideosTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbImportPicsFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbImportPicsTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog VideoFolder;
        private System.Windows.Forms.FolderBrowserDialog PictureFolder;
        private System.Windows.Forms.TextBox tbImportPicsTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbImportPicsFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbImportVideosTo;
        private System.Windows.Forms.Button btnImportPicturesFrom;
        private System.Windows.Forms.Button btnImportPicturesTo;
        private System.Windows.Forms.Button btnImportVideosTo;
        private System.Windows.Forms.FolderBrowserDialog ImportPicturesFromFolder;
    }
}

