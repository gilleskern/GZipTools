using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kbg.NppPluginNET
{
    public partial class AboutDlg : Form
    {
        private string Version = "1.02";    // Add encryption & settings

        public AboutDlg()
        {
            InitializeComponent();

            AboutBox.Text += Version;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Call the Process.Start method to open the default browser with a URL:
            System.Diagnostics.Process.Start("https://github.com/gilleskern/GZipTools");
        }
    }
}
