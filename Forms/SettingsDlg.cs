﻿using System;
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
        public Model.Settings Settings
        {
            get
            {
                return _settings;
            }
        }

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
            comboBoxSelectKey.Items.AddRange(_settings.AES.Keys.ToArray());
            comboBoxSelectKey.SelectedItem = _settings.AES.SelectedKey;

            if (_settings.AES.SelectedKey != null)
            {
                textBoxKeyID.Text = _settings.AES.SelectedKey.Name;
                textBoxKeyValue.Text = _settings.AES.SelectedKey.Value; 
            }
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

                // Add key to combobox
                comboBoxSelectKey.Items.Add(key);
                comboBoxSelectKey.SelectedItem = key;
            }
            else
            {
                // 3) update existing key
                int index = comboBoxSelectKey.Items.IndexOf(key);

                Model.Key comboKey = (Model.Key)comboBoxSelectKey.Items[index];
                comboKey.Value = textBoxKeyValue.Text;
                comboBoxSelectKey.SelectedItem = comboKey;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSelectKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Key selectedItem = (Model.Key)comboBoxSelectKey.SelectedItem;
            textBoxKeyID.Text = selectedItem.Name;
            textBoxKeyValue.Text = selectedItem.Value;
            _settings.AES.SelectedKey = selectedItem;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // 1) Write settings to file
            Helper.Settings.Write(_settings);

            // 2) Return settings
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
