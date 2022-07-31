using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTools.Helper
{
    public struct Constants
    {
        public struct Plugin
        {
            public const string Name = "GZipTools";
        }

        public struct MessageBox
        {
            public struct Caption
            {
                public const string SettingsNotFound = "Settings not found";
                public const string KeyNotFound = "No key selected";
                public const string DeleteKey = "Delete key";
            }

            public struct Text
            {
                public const string SettingsFromMenu = "Please add settings from menu";
                public const string SelectKey = "Please select key from settings";
                public const string AreYouSure = "Are you sure?";
            }
        }
    }
}
