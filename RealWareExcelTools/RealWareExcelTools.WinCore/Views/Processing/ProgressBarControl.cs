using System;

namespace RealWareExcelTools.WinCore.Views.Processing
{
    public partial class ProgressBarControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ProgressBarControl()
        {
            InitializeComponent();

            statusController.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        public void SetToLoading(string header)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetToLoading(header)));
                return;
            }

            progressPanel1.Caption = header ?? "Processing...";
            statusController.SelectedTabPage = tabLoading;
        }

        public void SetToError(string header, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetToError(header, message)));
                return;
            }

            lblErrorHeader.Text = header;
            lblErrorMessage.Text = message;
            statusController.SelectedTabPage = tabError;
        }

        public void SetToSuccess(string header, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetToSuccess(header, message)));
                return;
            }

            lblSuccessHeader.Text = header;
            lblSuccessMessage.Text = message;
            statusController.SelectedTabPage = tabSuccess;
        }
    }
}
