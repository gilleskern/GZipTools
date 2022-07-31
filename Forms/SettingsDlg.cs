using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

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

        public SettingsDlg()
        {
            InitializeComponent();

            // Load settings
            _settings = Helper.Settings.Read();

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

            // Initialise controls
            comboBoxSelectKey.Items.AddRange(_settings.AES.Keys.ToArray());
            comboBoxSelectKey.SelectedItem = _settings.AES.Keys.FirstOrDefault(k => k.Name == _settings.AES.SelectedKey.Name);

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
            lblKeyAction.Visible = false;
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

                lblKeyAction.Visible = true;
                lblKeyAction.Text = "Added";
                lblKeyAction.ForeColor = Color.Blue;
            }
            else
            {
                //var update = MessageBox.Show(Constants.MessageBox.Text.AreYouSure, Constants.MessageBox.Caption.UpdateKey, MessageBoxButtons.YesNo);
                //if(update == DialogResult.Yes)

                // 3) update existing key
                int index = comboBoxSelectKey.Items.IndexOf(key);

                Model.Key comboKey = (Model.Key)comboBoxSelectKey.Items[index];
                comboKey.Value = textBoxKeyValue.Text;
                comboBoxSelectKey.SelectedItem = comboKey;

                lblKeyAction.Visible = true;
                lblKeyAction.Text = "Updated";
                lblKeyAction.ForeColor = Color.Green; 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblKeyAction.Visible = false;

            //var delete = MessageBox.Show(Constants.MessageBox.Text.AreYouSure, Constants.MessageBox.Caption.DeleteKey, MessageBoxButtons.YesNo);
            //if (delete == DialogResult.Yes)

            // 1) Get selected item
            Model.Key selectedItem = (Model.Key)comboBoxSelectKey.SelectedItem;
            var key = _settings.AES.Keys.FirstOrDefault(k => k.Name == selectedItem.Name);

            if (key != null)
            {
                // 2) Remove key from settings
                _settings.AES.Keys.Remove(key);

                // 3) Update dialog
                comboBoxSelectKey.Items.Remove(key);

                if (comboBoxSelectKey.Items.Count == 0)
                {
                    textBoxKeyID.Text = string.Empty;
                    textBoxKeyValue.Text = string.Empty;
                    comboBoxSelectKey.Text = string.Empty;
                    comboBoxSelectKey.SelectedItem = null;
                    _settings.AES.SelectedKey = null;
                }
                else
                {
                    Model.Key prevKey = (Model.Key)comboBoxSelectKey.Items[0];
                    comboBoxSelectKey.SelectedItem = prevKey;
                }
            }
        }

        private void comboBoxSelectKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKeyAction.Visible = false;
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
