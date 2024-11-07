using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Views.Batch.Items
{
    public partial class SinglePathBatch : DevExpress.XtraEditors.XtraUserControl, IBatchScriptItem
    {
        private Core.Providers.IScriptDataProvider dataProvider;

        private string selectedExcelValue = "";
        private string selectedStaticValue = "";

        private readonly bool _isApiLookup;

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
        }

        public SinglePathBatch(string name, bool isApiLookup, Core.Providers.IScriptDataProvider dataProvider) : this()
        {
            txtName.Text = name;
            _isApiLookup = isApiLookup;
            this.dataProvider = dataProvider;

            refreshView();
        }

        public bool IsValid()
        {
            return true;
        }

        private void refreshView()
        {
            drpValue.Properties.Items.Clear();

            if (toggleUseExcelValue.IsOn)
            {
                var data = dataProvider.ExcelProvider.GetValidColumnNames();
                drpValue.Properties.Items.AddRange(data);       //TODO: Need to remove bad columns
                //drpValue2.Properties.DataSource = data.ToDictionary(x=>x,x=>x);
                drpValue2.Properties.DataSource = data.Select(x=>new LookupItem() { Key = x, Value = x }).ToList();
            }
            else
            {
                var data = getStaticData();
                drpValue.Properties.Items.AddRange(data);
                //drpValue2.Properties.DataSource = data;
                drpValue2.Properties.DataSource = data.Select(x => new LookupItem() { Key = x.Key, Value = x.Value }).ToList();
            }
            drpValue2.Properties.ForceInitialize();
            drpValue2.Properties.PopulateColumns();

            bool isVisible = (((List<LookupItem>)drpValue2.Properties.DataSource)
                .FindAll(x=>x.Key != x.Value).Count() > 0);
            drpValue2.Properties.Columns[1].Visible = isVisible;
        }

        private Dictionary<string, string> getStaticData()
        {
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

        private void toggleUseExcelValue_Toggled(object sender, EventArgs e)
        {
            drpValue.Text = toggleUseExcelValue.IsOn ? selectedExcelValue : selectedStaticValue;

            refreshView();
        }

        private void drpValue_TextChanged(object sender, EventArgs e)
        {
            if(toggleUseExcelValue.IsOn)
            {
                selectedExcelValue = drpValue.Text;
            }
            else
            {
                selectedStaticValue = drpValue.Text;
            }

            refreshView();
        }
        
    }
}
