using System;

namespace RealWareExcelTools.Core.Settings
{
    public class AddinSettingsIO
    {
        const string SETTINGS_FILE_NAME = "RealWareExcelToolsSettings.json";

        public static AddinSettings ReadSettingsFromFile()
        {
            if (!System.IO.File.Exists(SETTINGS_FILE_NAME))
            {
                var result = CreateSettingsFile();
                return result;
            }
            else
            {
                try
                {
                    string data = System.IO.File.ReadAllText(SETTINGS_FILE_NAME);

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<AddinSettings>(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error reading settings file: " + ex.Message, ex);
                }
            }
        }

        public static AddinSettings CreateSettingsFile()
        {
            var settings = new AddinSettings();

            var data = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);

            try
            {
                System.IO.File.WriteAllText(SETTINGS_FILE_NAME, data);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating settings file: " + ex.Message, ex);
            }

            return settings;
        }
    }
}
