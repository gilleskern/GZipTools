using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTools.Helper
{
    public class Settings
    {
        public static async Task<Model.Settings> ReadAsync()
        {
            string fileName = FileUtil.GetConfigFilePath();

            // Check file exist
            if (File.Exists(fileName))
            {
                string fileText = await FileUtil.ReadAllTextAsync(fileName);
                var settings = JsonConvert.DeserializeObject<Model.Settings>(fileText);
                return settings;
            }

            return null;
        }

        public static Model.Settings Read()
        {
            string fileName = FileUtil.GetConfigFilePath();

            // Check file exist
            if (File.Exists(fileName))
            {
                string fileText = File.ReadAllText(fileName);
                var settings = JsonConvert.DeserializeObject<Model.Settings>(fileText);
                return settings;
            }

            return null;
        }

        public static void Write(Model.Settings settings)
        {
            string fileName = FileUtil.GetConfigFilePath();
            string jsonText = JsonConvert.SerializeObject(settings);
            File.WriteAllText(fileName, jsonText);
        }
    }
}
