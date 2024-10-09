using RealWareExcelTools.Modules.Batch.Models;
using System;
using System.Collections.Generic;

namespace RealWareExcelTools.Modules.Batch.Controller
{
    public class ScriptFileController
    {
        private readonly string baseScriptDirectory;

        public ScriptFileController(string baseScriptDirectory)
        {
            this.baseScriptDirectory = baseScriptDirectory;
        }

        public void WriteScriptToFile(BatchModule module, ApiOperation operation, 
            string name, BatchScript script)
        {
            System.IO.Directory.CreateDirectory(baseScriptDirectory);

            var data = Newtonsoft.Json.JsonConvert.SerializeObject(script, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(
                System.IO.Path.Combine(baseScriptDirectory, GetScriptName(module, operation, name)), data);
        }

        public BatchScript ReadScriptFromFile(BatchModule module, ApiOperation operation, string name)
        {
            string fileName = GetScriptName(module, operation, name);
            string filePath = System.IO.Path.Combine(baseScriptDirectory, fileName);

            if (!System.IO.File.Exists(filePath))
                return null;

            string data = System.IO.File.ReadAllText(filePath);
            var script = Newtonsoft.Json.JsonConvert.DeserializeObject<BatchScript>(data);

            return script;
        }

        public Dictionary<string, string> ReadScriptFileNames(BatchModule module, ApiOperation operation)
        {
            var result = new Dictionary<string, string>();

            if(!System.IO.Directory.Exists(baseScriptDirectory))
                return result;

            string moduleName = Enum.GetName(typeof(BatchModule), module);
            string operationName = Enum.GetName(typeof(ApiOperation), operation);
            string scriptWildcardName = GetScriptName(module, operation, "*");
            string scriptPrefix = $"{moduleName}_{operationName}_";
            string[] files = System.IO.Directory.GetFiles(baseScriptDirectory, scriptWildcardName);

            foreach(var file in files)
            {
                string cleanFileName = file
                    .Substring(file.IndexOf(scriptPrefix) + scriptPrefix.Length)
                    .Replace(".json", ""); ;

                result.Add(cleanFileName, file);
            }

            return result;
        }

        public string GetScriptName(BatchModule module, ApiOperation operation, string name)
        {
            string moduleName = Enum.GetName(typeof(BatchModule), module);
            string operationName = Enum.GetName(typeof(ApiOperation), operation);
            return $"{moduleName}_{operationName}_{name}.json";
        }
    }
}
