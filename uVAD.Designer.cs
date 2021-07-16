
using System.Windows.Forms;

namespace Launcher
{
    partial class uVAD
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uVAD));
            this.download = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.link = new System.Windows.Forms.TextBox();
            this.fileFormat = new System.Windows.Forms.Button();
            this.LinkLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ftype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputCom = new System.Windows.Forms.TextBox();
            this.dlWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.format = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // download
            // 
            this.download.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.download.FlatAppearance.BorderSize = 0;
            this.download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.download.ForeColor = System.Drawing.SystemColors.ControlText;
            this.download.Image = global::LauncherDL.Properties.Resources.asutorufo;
            this.download.Location = new System.Drawing.Point(9, 322);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(415, 52);
            this.download.TabIndex = 0;
            this.download.Text = "Download";
            this.download.UseVisualStyleBackColor = false;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.update.Image = global::LauncherDL.Properties.Resources.venti;
            this.update.Location = new System.Drawing.Point(224, 264);
            this.update.Name = "update";
            this.update.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.update.Size = new System.Drawing.Size(200, 52);
            this.update.TabIndex = 0;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // link
            // 
            this.link.CausesValidation = false;
            this.link.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.link.Location = new System.Drawing.Point(8, 152);
            this.link.Name = "link";
            this.link.PlaceholderText = "Link here";
            this.link.Size = new System.Drawing.Size(416, 34);
            this.link.TabIndex = 1;
            this.link.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fileFormat
            // 
            this.fileFormat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileFormat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fileFormat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileFormat.FlatAppearance.BorderSize = 0;
            this.fileFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileFormat.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileFormat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileFormat.Image = global::LauncherDL.Properties.Resources.akira;
            this.fileFormat.Location = new System.Drawing.Point(10, 264);
            this.fileFormat.Name = "fileFormat";
            this.fileFormat.Size = new System.Drawing.Size(200, 52);
            this.fileFormat.TabIndex = 0;
            this.fileFormat.Text = "File Formats";
            this.fileFormat.UseVisualStyleBackColor = false;
            this.fileFormat.Click += new System.EventHandler(this.fileFormat_Click);
            // 
            // LinkLabel
            // 
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.LinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LinkLabel.ForeColor = System.Drawing.Color.Black;
            this.LinkLabel.Location = new System.Drawing.Point(192, 128);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(53, 22);
            this.LinkLabel.TabIndex = 2;
            this.LinkLabel.Text = "Link:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(64, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Options:";
            // 
            // Ftype
            // 
            this.Ftype.AllowDrop = true;
            this.Ftype.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Ftype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ftype.DisplayMember = "None";
            this.Ftype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ftype.FormattingEnabled = true;
            this.Ftype.Items.AddRange(new object[] {
            "Custom",
            "Video",
            "Audio"});
            this.Ftype.Location = new System.Drawing.Point(152, 56);
            this.Ftype.Name = "Ftype";
            this.Ftype.Size = new System.Drawing.Size(136, 28);
            this.Ftype.TabIndex = 0;
            this.Ftype.ValueMember = "None";
            this.Ftype.SelectedIndexChanged += new System.EventHandler(this.Ftype_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(168, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Type:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(136, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Prefer MP3 Format";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(320, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "open folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "©copyright 2021 kasura";
            this.label3.Click += new System.EventHandler(this.Hidden);
            // 
            // outputCom
            // 
            this.outputCom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputCom.HideSelection = false;
            this.outputCom.Location = new System.Drawing.Point(8, 384);
            this.outputCom.Margin = new System.Windows.Forms.Padding(4);
            this.outputCom.Multiline = true;
            this.outputCom.Name = "outputCom";
            this.outputCom.ReadOnly = true;
            this.outputCom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputCom.ShortcutsEnabled = false;
            this.outputCom.Size = new System.Drawing.Size(416, 186);
            this.outputCom.TabIndex = 5;
            this.outputCom.TabStop = false;
            this.outputCom.Text = "welcome, めぐみん here!\r\n[NOTE] Run \"file formats\" to get more options\r\n[NOTE] Read t" +
    "he \"readme.txt\" if it\'s your first time using this";
            this.outputCom.TextChanged += new System.EventHandler(this.outputCom_TextChanged);
            // 
            // dlWorker
            // 
            this.dlWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dlWorker_DoWork);
            this.dlWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dlWorker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 576);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(432, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            // 
            // FileName
            // 
            this.FileName.CausesValidation = false;
            this.FileName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileName.Location = new System.Drawing.Point(224, 216);
            this.FileName.Name = "FileName";
            this.FileName.PlaceholderText = "(optional)";
            this.FileName.Size = new System.Drawing.Size(200, 34);
            this.FileName.TabIndex = 7;
            this.FileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(264, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "File Name:";
            // 
            // format
            // 
            this.format.AllowDrop = true;
            this.format.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.format.Cursor = System.Windows.Forms.Cursors.Hand;
            this.format.DropDownWidth = 320;
            this.format.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.format.FormattingEnabled = true;
            this.format.IntegralHeight = false;
            this.format.Items.AddRange(new object[] {
            "best"});
            this.format.Location = new System.Drawing.Point(8, 216);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(200, 33);
            this.format.TabIndex = 9;
            // 
            // uVAD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 602);
            this.Controls.Add(this.format);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.outputCom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Ftype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LinkLabel);
            this.Controls.Add(this.fileFormat);
            this.Controls.Add(this.link);
            this.Controls.Add(this.update);
            this.Controls.Add(this.download);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "uVAD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher DL (Build Version 4.6)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.uVAD_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.uVAD_FormClosed);
            this.Load += new System.EventHandler(this.uVAD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button fileFormat;
        private System.Windows.Forms.Label LinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Ftype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputCom;
        private System.ComponentModel.BackgroundWorker dlWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private TextBox FileName;
        private Label label4;
        private ComboBox format;
    }
}

