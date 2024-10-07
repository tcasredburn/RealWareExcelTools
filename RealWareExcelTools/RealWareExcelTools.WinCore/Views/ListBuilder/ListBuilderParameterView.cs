using DevExpress.XtraSplashScreen;
using RealWare.Core.API.Models;
using System;
using System.Collections.Generic;

namespace RealWareExcelTools.WinCore.Views.ListBuilder
{
    /// <summary>
    /// View for editing and displaying the parameters for a list builder query.
    /// </summary>
    public partial class ListBuilderParameterView : DevExpress.XtraEditors.XtraUserControl
    {
        private string defaultTaxYear = string.Empty;
        private IOverlaySplashScreenHandle progressWheelHandle;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ListBuilderParameterView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the parameters into the grid.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="defaultTaxYear"></param>
        public void LoadParameters(string[] parameters, string defaultTaxYear = null)
        {
            progressWheelHandle = Helpers.Progress.CreateProgressPanel(gridControl1);

            if(defaultTaxYear != null)
                this.defaultTaxYear = defaultTaxYear;

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

            StopLoading();
        }

        /// <summary>
        /// Stops the loading of the grid.
        /// </summary>
        public void StopLoading()
        {
            Helpers.Progress.CloseProgressPanel(progressWheelHandle);
            progressWheelHandle = null;
        }

        /// <summary>
        /// Loads the grid with the parameters in a thread-safe way.
        /// </summary>
        /// <param name="parameters"></param>
        private void loadGrid(List<RWListBuilderQueryParameter> parameters)
        {
            if (gridControl1 == null)
                return;

            if (gridControl1.InvokeRequired)
            {
                gridControl1?.Invoke((Action)(() => loadGrid(parameters)));
                return;
            }

            gridControl1.DataSource = parameters;
            gridView1.RefreshData();
        }

        /// <summary>
        /// Returns the default value for the parameter (if exists).
        /// Note: This could definitely be improved to a system that can maintain this better.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        private string getDefaultParameterValue(string parameterName)
        {
            switch (parameterName.ToUpper())
            {
                case "VERSION":
                    return defaultTaxYear + "1231999";
                case "TAXYEAR":
                    return defaultTaxYear;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Data Source for the grid.
        /// </summary>
        public class RWListBuilderQueryParameterDS
        {
            public List<RWListBuilderQueryParameter> List { get; set; }
        }
    }
}
