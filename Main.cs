﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using GZipTools;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "GZipTools";

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
            PluginBase.SetCommand(0, "Compress test", CompressText, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(1, "Uncompress text", UncompressText, new ShortcutKey(false, false, false, Keys.None));
        }

        internal static void SetToolBarIcon()
        {

        }

        internal static void PluginCleanUp()
        {

        }

        internal static void CompressText()
        {
            new Compress(new ScintillaGateway(PluginBase.GetCurrentScintilla())).GZip();
        }

        internal static void UncompressText()
        {
            new Compress(new ScintillaGateway(PluginBase.GetCurrentScintilla())).GUnzip();
        }

    }
}