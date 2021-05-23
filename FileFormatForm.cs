using Launcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LauncherDL
{
    public partial class Formats : Form
    {
        public Formats()
        {
            InitializeComponent();
            if(FFFText.Text != "")
            {
                FFFText.Text = uVAD.Val;
            } else
            {
                FFFText.Text = "";
                FFFText.Text = uVAD.Val;
            }
            this.Text = $"File Format - \"{uVAD.title}\"";
        }

        private void FileFormatForm_Load(object sender, EventArgs e)
        {

        }
        private void FFFText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
