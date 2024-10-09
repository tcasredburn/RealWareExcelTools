using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using RealWare.Core.API.Models;
using System;
using System.Collections.Generic;

namespace RealWareExcelTools.WinCore.Views.ListBuilder
{
    public partial class ListBuilderQueryGrid : DevExpress.XtraEditors.XtraUserControl, IRealWareExcelToolView
    {
        public event EventHandler DataChangeEvent;
        public event EventHandler<RWListBuilderQueryItem> ParametersRequestEvent;

        public RWListBuilderQueryItem SelectedListBuilderItem { get; private set; }
        public string[] Parameters { get; private set; }

        private string taxYear;

        public List<RWListBuilderQueryParameter> GetParameters()
            => listBuilderParameterView1.GetParametersWithValues();

        IOverlaySplashScreenHandle loadResultsHandle;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListBuilderQueryGrid()
        {
            InitializeComponent();

            // Events
            gridView1.FocusedRowObjectChanged += gridView1_FocusedRowObjectChanged;
        }
        
        /// <summary>
        /// Sets the default tax year for versioning and tax year parameters.
        /// </summary>
        /// <param name="taxYear"></param>
        internal void SetDefaultTaxYear(string taxYear)
            => this.taxYear = taxYear;

        /// <summary>
        /// Show loading panel when first loaded.
        /// </summary>
        protected override void OnFirstLoad()
        {
            loadResultsHandle = Helpers.Progress.CreateProgressPanel(gridControl1);
        }

        /// <summary>
        /// On load event called when first loaded
        /// </summary>
        /// <param name="data"></param>
        public void OnLoad(object data)
            => loadGrid(data);

        /// <summary>
        /// Loads the grid with the parameters in a thread-safe way.
        /// </summary>
        /// <param name="parameters"></param>
        private void loadGrid(object data)
        {
            if (gridControl1 == null)
                return;

            if (gridControl1.InvokeRequired)
            {
                gridControl1?.Invoke((Action)(() => loadGrid(data)));
                return;
            }

            // Clear previous data
            gridControl1.DataSource = null;
            gridControl1.MainView.PopulateColumns();
            gridControl1.RefreshDataSource();

            // Set to new data
            if (data != null)
            {
                gridControl1.DataSource = data;
                gridControl1.RefreshDataSource();
            }

            StopLoading();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            SelectedListBuilderItem = gridView1.GetRow(e.FocusedRowHandle) as RWListBuilderQueryItem;
            Parameters = null;

            if (SelectedListBuilderItem != null)
            {
                ParametersRequestEvent?.Invoke(this, SelectedListBuilderItem);
            }

            DataChangeEvent?.Invoke(this, EventArgs.Empty);
        }

        internal void LoadParameters(string[] parameters)
        {
            this.Parameters = parameters ?? new string[0];
            listBuilderParameterView1.LoadParameters(parameters, taxYear);
        }

        /// <summary>
        /// Stops the loading of the grid.
        /// </summary>
        public void StopLoading()
        {
            Helpers.Progress.CloseProgressPanel(loadResultsHandle);
            loadResultsHandle = null;
        }


        /// <summary>
        /// Cleanup when the form is closing.
        /// </summary>
        internal void OnCloseCleanup()
        {
            StopLoading();
            listBuilderParameterView1.StopLoading();
        }

        
    }
}
