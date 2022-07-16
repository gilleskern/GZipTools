using GZipTools;
using GZipTools.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Windows.Forms;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "GZipTools";

        private static Compress compress = new Compress(new ScintillaGateway(PluginBase.GetCurrentScintilla()));

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
            PluginBase.SetCommand(0, "Compress text", CompressText, new ShortcutKey(true, false, true, Keys.C));
            PluginBase.SetCommand(1, "Decompress text", UncompressText, new ShortcutKey(true, false, true, Keys.D));
            PluginBase.SetCommand(2, string.Empty, null); // Add separator
            PluginBase.SetCommand(3, "Settings...", Settings, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(4, string.Empty, null); // Add separator
            PluginBase.SetCommand(5, "&About " + PluginName, ShowAbout, new ShortcutKey(false, false, false, Keys.None));
        }

        internal static void SetToolBarIcon()
        {

        }

        internal static void PluginCleanUp()
        {

        }

        internal static void CompressText()
        {
            compress.GZip();
        }

        internal static void UncompressText()
        {
            compress.GUnzip();
        }

        internal static void Settings()
        {
            //List<string> text = new List<string>()
            //{
            //    "one",
            //    "two",
            //    "three"
            //};
            //var jsonText = JsonConvert.SerializeObject(text, Formatting.Indented);
            //MessageBox.Show(jsonText, "Fody", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (SettingsDlg settings = new SettingsDlg())
            {
                settings.ShowDialog();
            }
        }

        private static void ShowAbout()
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