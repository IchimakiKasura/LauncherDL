
namespace LauncherDL
{
    partial class Formats
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
            this.FFFText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FFFText
            // 
            this.FFFText.BackColor = System.Drawing.Color.White;
            this.FFFText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FFFText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FFFText.Location = new System.Drawing.Point(8, 8);
            this.FFFText.Multiline = true;
            this.FFFText.Name = "FFFText";
            this.FFFText.ReadOnly = true;
            this.FFFText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FFFText.Size = new System.Drawing.Size(704, 344);
            this.FFFText.TabIndex = 0;
            this.FFFText.TabStop = false;
            this.FFFText.TextChanged += new System.EventHandler(this.FFFText_TextChanged);
            // 
            // Formats
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(718, 359);
            this.Controls.Add(this.FFFText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Formats";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Formats";
            this.Load += new System.EventHandler(this.FileFormatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox FFFText;
    }
}