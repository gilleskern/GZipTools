using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GZipTools.Forms
{
    public partial class SettingsDlg : Form
    {
        public SettingsDlg()
        {
            InitializeComponent();

            // To Do: Load settings from file
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Create a key by hashing the current date & time
            string dtHash = DateTime.Now.Ticks.ToString();

            HashAlgorithm hash = SHA512.Create();
            textBoxKeyValue.Text = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(dtHash)));
        }
    }
}
