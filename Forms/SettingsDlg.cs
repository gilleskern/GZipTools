using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GZipTools.Forms
{
    public partial class SettingsDlg : Form
    {
        private Model.Settings _settings;

        public SettingsDlg(Model.Settings settings)
        {
            InitializeComponent();

            // Load settings
            _settings = settings;

            if (_settings == null)
            {
                _settings = new Model.Settings
                {
                    AES = new Model.AES
                    {
                        Keys = new List<Model.Key>(),
                        SelectedKey = null
                    }
                };
            }

            // To Do: Initialise controls
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Create a new key
            var key = Aes.Create().Key;
            textBoxKeyValue.Text = Convert.ToBase64String(key);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1) check if key exist
            var key = _settings.AES.Keys.FirstOrDefault(k => k.Name == textBoxKeyID.Text);

            // 2) Add new key
            if (key == null)
            {
                key = new Model.Key
                {
                    Name = textBoxKeyID.Text,
                    Value = textBoxKeyValue.Text
                };

                _settings.AES.Keys.Add(key);
            }
            else
            {
                // 3) update existing key
                key.Value = textBoxKeyValue.Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
