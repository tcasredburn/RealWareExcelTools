using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using TCA.Framework.RealWare.Api.Model.Dto;
using TCA.Framework.WinCore.Helpers;

namespace RealWareExcelTools.WinCore.Views.ListBuilder
{
    public partial class ListBuilderQueryGrid : DevExpress.XtraEditors.XtraUserControl, IRealWareExcelToolView
    {
        public ListBuilderQueryItemDto SelectedListBuilderItem { get; private set; }

        IOverlaySplashScreenHandle loadResultsHandle;

        public ListBuilderQueryGrid()
        {
            InitializeComponent();

            gridView1.FocusedRowObjectChanged += gridView1_FocusedRowObjectChanged;
        }

        protected override void OnFirstLoad()
        {
            loadResultsHandle = Progress.CreateProgressPanel(gridControl1);
        }

        public void OnLoad(object data)
        {
            gridControl1.DataSource = null;
            gridControl1.MainView.PopulateColumns();
            gridControl1.RefreshDataSource();
            gridControl1.DataSource = data;
            gridControl1.RefreshDataSource();

            if (loadResultsHandle != null)
                Progress.CloseProgressPanel(loadResultsHandle);
        }

        private void gridView1_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            SelectedListBuilderItem = gridView1.GetRow(e.FocusedRowHandle) as ListBuilderQueryItemDto;
        }
    }
}
