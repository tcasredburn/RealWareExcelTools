using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using RealWare.Core.API.Connection;
using RealWareExcelTools.Core;
using RealWareExcelTools.Core.Modules.RealWareApiAssistant;
using RealWareExcelTools.Core.Providers;
using RealWareExcelTools.Modules.Batch.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealWareExcelTools.Modules.Batch.Controller
{
    /// <summary>
    /// IMPORTANT: This will be moved to RealWare.Core once this has been proven to work.
    ///            I just need to solve this problem now so it can be in use. 
    ///            - TODO: Move to RealWare.Core
    /// </summary>
    public class BatchRealWareScriptGenerator
    {
        private HashSet<BatchScriptMappingValue> _mappingValues;

        private readonly RealWareApiConnection _apiConnection;
        private readonly ILogger _logger;

        public BatchRealWareScriptGenerator(RealWareApiConnection apiConnection, ILogger logger)
        {
            _apiConnection = apiConnection;
            _logger = logger;
        }

        public ApiScript GenerateScript(BatchConfigurationScript script, string logFileLocation = null)
        {
            return new ApiScript()
            {
                ApiSettings = new RealWareApiSettings
                {
                    ApiPath = _apiConnection.BaseUrl,
                    Token = _apiConnection.ApiKey
                },

                ExcelFile = script.ExcelFilePath,
                ApiOperation = getOperation(script.Module),
                Method = script.Action.ToString(),
                
                IdColumns = getIdColumns(script),

                ValueChanges = getValueChanges(script),

                ValueInserts = new List<RealWareApiValue>(), // Currently not supported

                // Default Settings
                CustomLogFileLocation = logFileLocation,
                RetryImmediatelyAfterBadRequest = true,
                SkipConfirmations = false,
                SkipWarningPrompts = false,
                ExcelFileRowUpdateCount = 5000,
                RetryCount = script.RetryCount,
                RetryWaitTimeInMs = script.RetryDelay,
                Threads = script.ThreadCount,
                ForceExcelNULLValues = script.UseExcelNULLAsValue
            };
        }

        private List<RealWareApiValue> getValueChanges(BatchConfigurationScript script)
        {
            var result = new List<RealWareApiValue>();

            foreach(var mapping in script.MappingInfo)
            {
                var parts = mapping.RealWarePath.Split('.');
                var name = parts[parts.Length - 1];

                result.Add(new RealWareApiValue
                {
                    ExcelToColumn = mapping.DataSourceType == WinCore.Models.Batch.DataSourceType.Excel ? mapping.DataSourceName : null,
                    ToValue = mapping.DataSourceType == WinCore.Models.Batch.DataSourceType.Static ? mapping.DataSourceName : null,
                    Path = string.Join(".", parts.Take(parts.Length - 1)).Replace("[]", "[*]"),
                    RealWareColumn = name
                });
            }

            return result;
        }

        private List<RealWareApiId> getIdColumns(BatchConfigurationScript script)
        {
            var idColumns = new List<RealWareApiId>();

            if(script.IdValue1Type != IdValueType.None)
            {
                var name = script.IdValue1Type.ToString();
                idColumns.Add(new RealWareApiId
                {
                    IdName = "{" + char.ToLower(name[0]) + name.Substring(1) + "}",
                    ColumnValue = !script.IsIdValue1Static ? script.IdValue1 : null,
                    StaticValue = script.IsIdValue1Static ? script.IdValue1 : null
                });
            }

            if(script.IdValue2Type != IdValueType.None)
            {
                var name = script.IdValue2Type.ToString();
                idColumns.Add(new RealWareApiId
                {
                    IdName = "{" + char.ToLower(name[0]) + name.Substring(1) + "}",
                    ColumnValue = !script.IsIdValue2Static ? script.IdValue2 : null,
                    StaticValue = script.IsIdValue2Static ? script.IdValue2 : null
                });
            }

            if (script.IdValue3Type != IdValueType.None)
            {
                var name = script.IdValue3Type.ToString();
                idColumns.Add(new RealWareApiId
                {
                    IdName = "{" + char.ToLower(name[0]) + name.Substring(1) + "}",
                    ColumnValue = !script.IsIdValue3Static ? script.IdValue3 : null,
                    StaticValue = script.IsIdValue3Static ? script.IdValue3 : null
                });
            }

            return idColumns;
        }

        private string getOperation(BatchModule module)
        {
            switch (module)
            {
                case BatchModule.Account:
                    return "/api/realproperty/{accountNo}/{taxYear}";
                case BatchModule.Appeal:
                    return "/api/appeals/{appealNo}/{taxYear}";
                case BatchModule.Improvement:
                    return "/api/improvements/{accountNo}/{impNo}/{taxYear}";
                case BatchModule.Permit:
                    return "/api/permits/{permitNo}/{taxYear}";
                case BatchModule.Sale:
                    return "/api/sales/{receptionNo}";

                default:
                    throw new Exception("BatchModule not found.");
            }
        }
    }
}
