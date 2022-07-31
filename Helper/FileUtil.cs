using Kbg.NppPluginNET.PluginInfrastructure;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GZipTools.Helper
{
    public class FileUtil
    {
        public static async Task<string> ReadAllTextAsync(string filePath)
        {
            var stringBuilder = new StringBuilder();
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line = await streamReader.ReadLineAsync();
                while (line != null)
                {
                    stringBuilder.AppendLine(line);
                    line = await streamReader.ReadLineAsync();
                }
                return stringBuilder.ToString();
            }
        }

        private static string _configFilePath = string.Empty;

        public static string GetConfigFilePath()
        {
            if (string.IsNullOrEmpty(_configFilePath))
            {
                StringBuilder sbIniFilePath = new StringBuilder(Win32.MAX_PATH);
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETPLUGINSCONFIGDIR, Win32.MAX_PATH, sbIniFilePath);
                string iniFilePath = sbIniFilePath.ToString();

                if (!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);

                _configFilePath = Path.Combine(iniFilePath, Constants.Plugin.Name + ".json");
            }

            return _configFilePath;
        }
    }
}
