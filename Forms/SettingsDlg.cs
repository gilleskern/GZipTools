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
            // Create a new key
            var key = Aes.Create().Key;
            textBoxKeyValue.Text = Convert.ToBase64String(key);
        }
    }
}
