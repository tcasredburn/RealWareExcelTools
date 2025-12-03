using RealWareExcelTools.WinCore.Models.Batch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Views.Batch.Items
{
    public partial class SinglePathBatch : DevExpress.XtraEditors.XtraUserControl, IBatchScriptItem
    {
        private Core.Providers.IScriptDataProvider dataProvider;

        private string selectedExcelValue = "";
        private string selectedStaticValue = "";

        private readonly string _apiPath;
        private readonly bool _isApiLookup;
        private readonly SinglePathBatchType _valueType;

        public event EventHandler ScriptChangedEvent;

        public class LookupItem
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        public SinglePathBatch()
        {
            InitializeComponent();

            drpValue2.Properties.DataSource = new List<LookupItem>();
            drpValue2.Properties.DisplayMember = "Key";
            drpValue2.Properties.ValueMember = "Key";
            drpValue2.EditValueChanged += drpValue2_EditValueChanged;
            drpDateValue.EditValueChanged += drpDateValue_EditValueChanged;
            spinNumeric.EditValueChanged += spinNumeric_EditValueChanged;
        }

        private void spinNumeric_EditValueChanged(object sender, EventArgs e)
        {
            if (!toggleUseExcelValue.IsOn)
            {
                if(_valueType == SinglePathBatchType.NUMBER
                || _valueType == SinglePathBatchType.INTEGER)
                    selectedStaticValue = Convert.ToInt32(spinNumeric.EditValue).ToString();
                else if (_valueType == SinglePathBatchType.PERCENT)
                    selectedStaticValue = (((decimal)spinNumeric.EditValue) / 100.0m).ToString();
                else
                    selectedStaticValue = spinNumeric.EditValue.ToString();
                refreshView();
                ScriptChangedEvent?.Invoke(this, new EventArgs());
            }
        }

        private void drpDateValue_EditValueChanged(object sender, EventArgs e)
        {
            if (_valueType == SinglePathBatchType.DATE && !toggleUseExcelValue.IsOn)
            {
                selectedStaticValue = drpDateValue.DateTime.ToString();
                refreshView();
                ScriptChangedEvent?.Invoke(this, new EventArgs());
            }
        }

        public SinglePathBatch(string name, string apiPath, bool isApiLookup, 
            SinglePathBatchType valueType, Core.Providers.IScriptDataProvider dataProvider) : this()
        {
            txtName.Text = name;
            _apiPath = apiPath;
            _isApiLookup = isApiLookup;
            _valueType = valueType;
            this.dataProvider = dataProvider;

            if(_valueType == SinglePathBatchType.INTEGER)
            {
                spinNumeric.Properties.IsFloatValue = false;

                spinNumeric.Properties.Mask.EditMask = "N0";
                spinNumeric.Properties.Mask.UseMaskAsDisplayFormat = true;
                spinNumeric.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            }
            else if(_valueType == SinglePathBatchType.PERCENT)
            {
                spinNumeric.Properties.IsFloatValue = true;
                spinNumeric.Properties.Increment = 0.01m;
                spinNumeric.Properties.MinValue = 0m;
                spinNumeric.Properties.MaxValue = 100m;

                spinNumeric.Properties.Mask.EditMask = "P2";
                spinNumeric.Properties.Mask.UseMaskAsDisplayFormat = true;
                spinNumeric.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            }

            refreshView();
        }

        private void refreshValueType()
        {
            switch (_valueType)
            {
                case SinglePathBatchType.BOOLEAN:
                    break;
                case SinglePathBatchType.INTEGER:
                case SinglePathBatchType.NUMBER:
                case SinglePathBatchType.PERCENT:
                    {
                        spinNumeric.Visible = !toggleUseExcelValue.IsOn;
                        drpValue2.Visible = toggleUseExcelValue.IsOn;
                    }
                    break;
                case SinglePathBatchType.DATE:
                    {
                        drpDateValue.Visible = !toggleUseExcelValue.IsOn;
                        drpValue2.Visible = toggleUseExcelValue.IsOn;
                    }
                    break;
                case SinglePathBatchType.STRING:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsValid()
        {
            if(drpValue2.EditValue == null)
                return false;

            if(string.IsNullOrEmpty(drpValue2.EditValue.ToString()))
                return false;

            return true;
        }

        private void refreshView()
        {
            refreshValueType();

            if (toggleUseExcelValue.IsOn)
            {
                var data = dataProvider.ExcelProvider.GetValidColumnNames();
                drpValue2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                drpValue2.Properties.DataSource = data.Select(x=>new LookupItem() { Key = x, Value = x }).ToList();
                if(!string.IsNullOrEmpty(selectedExcelValue))
                    drpValue2.EditValue = selectedExcelValue;
            }
            else
            {
#if TULSA_COUNTY
                if (_apiPath == "LandAppraiser" || _apiPath == "Appraiser" 
                    || _apiPath == "Account.BusinessName" || _apiPath == "Account.PropertyIdentifier"
                    || _apiPath == "Occupancies[].AbstractCode" || _apiPath == "ImpDescription"
                    || _apiPath == "CostValueBy" || _apiPath == "MarketValueBy" || _apiPath == "IncomeValueBy")
                {
                    drpValue2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    if (!string.IsNullOrEmpty(selectedStaticValue))
                        drpValue2.EditValue = selectedStaticValue;
                }
                else
#endif
                {
                    var data = getStaticData();
                    drpValue2.Properties.DataSource = data.Select(x => new LookupItem() { Key = x.Key, Value = x.Value }).ToList();
                    if (!string.IsNullOrEmpty(selectedStaticValue))
                        drpValue2.EditValue = selectedStaticValue;
                }
            }
            drpValue2.Properties.ForceInitialize();
            drpValue2.Properties.PopulateColumns();

            bool isVisible = (((List<LookupItem>)drpValue2.Properties.DataSource)
                .FindAll(x=>x.Key != x.Value).Count() > 0);
            drpValue2.Properties.Columns[1].Visible = isVisible;
        }

        private Dictionary<string, string> getStaticData()
        {
            if(_valueType == SinglePathBatchType.NUMBER 
                || _valueType == SinglePathBatchType.INTEGER 
                || _valueType == SinglePathBatchType.PERCENT)
                return new Dictionary<string, string>()
                {
                    { selectedStaticValue, selectedStaticValue }
                };

            if (_valueType == SinglePathBatchType.BOOLEAN)
            {
                return new Dictionary<string, string>()
                {
                    { "True", "true" },
                    { "False", "false" }
                };
            }

            if (_valueType != SinglePathBatchType.STRING)
            {
                var data = new Dictionary<string, string>();
                if (selectedStaticValue != null)
                    data.Add(selectedStaticValue, selectedStaticValue);
                return data;
            }
            else if (_valueType == SinglePathBatchType.STRING
                    && _apiPath.EndsWith("ValueBy"))
                return getValueByData();
            else if (_valueType == SinglePathBatchType.STRING
                    && _apiPath.EndsWith("Method"))
                return getMethodData(_apiPath);

            try
            {
                var result = dataProvider.DataProvider.GetLookup(txtName.Text, true);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Dictionary<string, string>();
            }
        }

        private Dictionary<string, string> getValueByData()
            => new Dictionary<string, string>()
                    {
                        { "SF", "SF" },
                        { "Units", "Units" },   
                        { "Other", "Other" },
                        { "Rooms", "Rooms" }
                    };

        private Dictionary<string, string> getMethodData(string apiPath)
        {
            switch (apiPath)
            {
                case "CostValueBy":
                    return new Dictionary<string, string>()
                    {
                        { "External Cost Value", "External Cost Value" },
                        { "Override", "Override" },
                        { "MLPLD", "MLPLD" },
                        { "RCNLD", "RCNLD" }
                    };
                case "MarketValueBy":
                    return new Dictionary<string, string>()
                    {
                        { "External Market Value", "External Market Value" },
                        { "Override", "Override" },
                        { "Regression", "Regression" },
                        { "RegressionOverride", "RegressionOverride" }
                    };
                case "IncomeValueBy":
                    return new Dictionary<string, string>()
                    {
                        { "Direct Cap", "Direct Cap" },
                        { "Direct Cap Override", "Direct Cap Override" },
                        { "GIM", "GIM" },
                        { "GIM Override", "GIM Override" },
                        { "GRM", "GRM" },
                        { "GRM Override", "GRM Override" },
                        { "Mortgage Equity", "Mortgage Equity" },
                        { "Override", "Override" },
                        { "Regression", "Regression" },
                        { "Regression Override", "Regression Override" }
                    };
                default:
                    return new Dictionary<string, string>();
            }
        }

        private void toggleUseExcelValue_Toggled(object sender, EventArgs e)
        {
            //drpValue2.Text = toggleUseExcelValue.IsOn ? selectedExcelValue : selectedStaticValue;

            refreshView();
            drpValue2.EditValue = null;
            spinNumeric.EditValue = null;
            ScriptChangedEvent?.Invoke(this, new EventArgs());
        }

        private void drpValue2_EditValueChanged(object sender, EventArgs e)
        {
            if (toggleUseExcelValue.IsOn)
                selectedExcelValue = (string)drpValue2.EditValue;
            else
                selectedStaticValue = (string)drpValue2.EditValue;

            refreshView();
            ScriptChangedEvent?.Invoke(this, new EventArgs());
        }

        public BatchScriptMappingInfo GetBatchInfo()
        {
            string realWareColumnName = _apiPath.Split('.').Last();

            return new BatchScriptMappingInfo()
            {
                DataSourceType = toggleUseExcelValue.IsOn ? DataSourceType.Excel : DataSourceType.Static,
                DataSourceName = toggleUseExcelValue.IsOn ? selectedExcelValue : selectedStaticValue,
                RealWarePath = _apiPath,
                RealWareColumnName = realWareColumnName
            };
        }
    }
}
