using System;

namespace RealWareExcelTools.Core.Settings
{
    public class AddinSettingsIO
    {
        const string SETTINGS_FILE_NAME = "RealWareExcelToolsSettings.json";

        public static AddinSettings ReadSettingsFromFile()
        {
            string filePath = GetFullSettingFilePath();

            if (!System.IO.File.Exists(filePath))
            {
                var result = WriteSettingsToFile(new AddinSettings());
                return result;
            }
            else
            {
                try
                {
                    string data = System.IO.File.ReadAllText(filePath);

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<AddinSettings>(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading settings file: " + ex.Message, ex);
                }
            }
        }

        public static AddinSettings WriteSettingsToFile(AddinSettings addinSettings)
        {
            var settings = addinSettings;

            var data = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);

            try
            {
                string filePath = GetFullSettingFilePath();

                System.IO.File.WriteAllText(filePath, data);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating settings file: " + ex.Message, ex);
            }

            return settings;
        }

        public static string GetFullSettingFilePath()
        {
           return System.IO.Path.Combine(GetAppDataPath(), SETTINGS_FILE_NAME);
        }

        public static string GetAppDataPath()
        {
            var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RealWareExcelTools");

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            return path;
        }
    }
}
