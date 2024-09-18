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
        public List<RWListBuilderQueryParameter> GetParameters()
        {
            return null;//TODO
        }

        IOverlaySplashScreenHandle loadResultsHandle;

        public ListBuilderQueryGrid()
        {
            InitializeComponent();

            gridView1.FocusedRowObjectChanged += gridView1_FocusedRowObjectChanged;
        }

        protected override void OnFirstLoad()
        {
            loadResultsHandle = Helpers.Progress.CreateProgressPanel(gridControl1);
        }

        public void OnLoad(object data)
        {
            gridControl1.DataSource = null;
            gridControl1.MainView.PopulateColumns();
            gridControl1.RefreshDataSource();
            gridControl1.DataSource = data;
            gridControl1.RefreshDataSource();

            if (loadResultsHandle != null)
                Helpers.Progress.CloseProgressPanel(loadResultsHandle);
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

            if(parameters.Length > 0)
            {
                layoutControlItemParamaters.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlItemParamaters.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                splitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            listBuilderParameterView1.LoadParameters(parameters);
        }
    }
}
