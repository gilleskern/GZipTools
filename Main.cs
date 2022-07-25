using GZipTools;
using GZipTools.Forms;
using Model = GZipTools.Model;
using Helper = GZipTools.Helper;
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Windows.Forms;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = Helper.Constants.Plugin.Name;

        private static Compress compress = new Compress(new ScintillaGateway(PluginBase.GetCurrentScintilla()));
        private static EncryptAES encryptAES = new EncryptAES(new ScintillaGateway(PluginBase.GetCurrentScintilla()));
        private static Model.Settings _settings = null;
        private static Model.Settings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Helper.Settings.Read();
                }

                return _settings;
            }

            set
            {
                _settings = value;
            }
        }

        public static void OnNotification(ScNotification notification)
        {  
            // This method is invoked whenever something is happening in notepad++
            // use eg. as
            // if (notification.Header.Code == (uint)NppMsg.NPPN_xxx)
            // { ... }
            // or
            //
            // if (notification.Header.Code == (uint)SciMsg.SCNxxx)
            // { ... }
        }

        internal static void CommandMenuInit()
        {
            PluginBase.SetCommand(0, "Compress text", CompressTextMenu, new ShortcutKey(true, false, true, Keys.C));
            PluginBase.SetCommand(1, "Decompress text", UncompressTextMenu, new ShortcutKey(true, false, true, Keys.D));
            PluginBase.SetCommand(2, string.Empty, null); // Add separator
            PluginBase.SetCommand(3, "Encrypt text", EncryptTextMenu, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(4, "Decrypt text", DecryptTextMenu, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(5, string.Empty, null); // Add separator
            PluginBase.SetCommand(6, "Settings...", SettingsMenu, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(7, string.Empty, null); // Add separator
            PluginBase.SetCommand(8, "&About " + PluginName, ShowAboutMenu, new ShortcutKey(false, false, false, Keys.None));
        }

        internal static void SetToolBarIcon()
        {

        }

        internal static void PluginCleanUp()
        {

        }

        internal static void CompressTextMenu()
        {
            compress.GZip();
        }

        internal static void UncompressTextMenu()
        {
            compress.GUnzip();
        }

        internal static void EncryptTextMenu()
        {
            encryptAES.Encrypt();
        }

        internal static void DecryptTextMenu()
        {
            encryptAES.Decrypt();
        }

        internal static void SettingsMenu()
        {
            using (SettingsDlg settingsDlg = new SettingsDlg())
            {
                var result = settingsDlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Settings = settingsDlg.Settings;
                }
            }
        }

        private static void ShowAboutMenu()
        {
            #region Old version
            //var message = new StringBuilder();
            //message.AppendLine("GZipTools Version: 1.00");
            //message.AppendLine("‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾");
            //message.AppendLine();
            //message.AppendLine("This plugin compress/decompress the content of the current window.");
            //message.AppendLine();
            //message.AppendLine("License: This is freeware (Apache v2.0 license).");
            //message.AppendLine();
            //message.AppendLine("Author: Gilles Kern 2022-");
            //message.AppendLine();
            //message.AppendLine("Website: https://github.com/gilleskern/GZipTools");

            //var title = PluginName;
            //MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Information); 
            #endregion

            using (AboutDlg about = new AboutDlg())
            {
                about.ShowDialog();
            }
        }

    }
}