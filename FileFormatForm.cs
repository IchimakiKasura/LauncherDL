using Launcher;
using System;
using System.Windows.Forms;

namespace LauncherDL
{
    public partial class Formats : Form
    {
        public Formats()
        {
            InitializeComponent();
            FFFText.Text = uVAD.Val;
            FFFText.SelectionStart = 0;
        }

        private void FileFormatForm_Load(object sender, EventArgs e)
        {

        }
        private void FFFText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
