using RealWare.Core.API.Models;
using System;
using System.Collections.Generic;

namespace RealWareExcelTools.WinCore.Views.ListBuilder
{
    public partial class ListBuilderParameterView : DevExpress.XtraEditors.XtraUserControl
    {
        string taxYear;

        public ListBuilderParameterView()
        {
            InitializeComponent();

            taxYear = DateTime.Now.Year.ToString(); //TODO: make this a setting instead
        }

        public void LoadParameters(string[] parameters)
        {
            var list = new List<RWListBuilderQueryParameter>();

            foreach (var parameter in parameters)
            {
                list.Add(new RWListBuilderQueryParameter
                {
                    ParameterName = parameter,
                    Value = getDefaultParameterValue(parameter)
                });
            }

            loadGrid(list);
        }

        private void loadGrid(List<RWListBuilderQueryParameter> parameters)
        {
            if (gridControl1.InvokeRequired)
            {
                gridControl1.Invoke((Action)(() => loadGrid(parameters)));
                return;
            }

            gridControl1.DataSource = parameters;
            gridView1.RefreshData();
        }

        private string getDefaultParameterValue(string parameterName)
        {
            switch (parameterName.ToUpper())
            {
                case "VERSION":
                    return taxYear + "1231999";
                case "TAXYEAR":
                    return taxYear;
                default:
                    return string.Empty;
            }
        }

        public class RWListBuilderQueryParameterDS
        {
            public List<RWListBuilderQueryParameter> List { get; set; }
        }
    }
}
