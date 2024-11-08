using DevExpress.XtraWizard;
using System;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public class PreSummaryPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        private DevExpress.XtraEditors.MemoEdit txtSummary;

        public string PageTitle => "Script Summary";

        public string PageDescription => "Verify everything looks correct before running through RealWare.";

        public PreSummaryPage()
        {
            InitializeComponent();
        }

        public void OnSavePage() { }

        public void OnRefreshPage(Direction? direction = null)
        { 
            if(direction == Direction.Forward)
            {
                loadSummaryText();
            }
        }

        private void loadSummaryText()
        {
            txtSummary.Text = "Summary of script:" + Environment.NewLine
                + Environment.NewLine
                + "Module: " + Context.Script.Module + Environment.NewLine
                + "Spreadsheet: " + Context.Script.SpreadsheetName + Environment.NewLine
                + Environment.NewLine
                + "Action: " + Context.Script.Action + Environment.NewLine
                + "ID Fields: " + Environment.NewLine + getIdFieldText() + Environment.NewLine
                + Environment.NewLine
                + "Values: " + getValueText() + Environment.NewLine;
        }

        private string getIdFieldText()
        {
            return
                  (string.IsNullOrEmpty(Context.Script.IdValue1) ? "" : $"    {Context.Script.IdValue1Type}=" + Context.Script.IdValue1 + (Context.Script.IsIdValue1Static ? "" : " (EXCEL COLUMN)") + Environment.NewLine)
                + (string.IsNullOrEmpty(Context.Script.IdValue2) ? "" : $"    {Context.Script.IdValue2Type}=" + Context.Script.IdValue2 + (Context.Script.IsIdValue2Static ? "" : " (EXCEL COLUMN)") + Environment.NewLine)
                + (string.IsNullOrEmpty(Context.Script.IdValue3) ? "" : $"    {Context.Script.IdValue3Type}=" + Context.Script.IdValue3 + (Context.Script.IsIdValue3Static ? "" : " (EXCEL COLUMN)") + Environment.NewLine);
        }

        private string getValueText()
        {

        }

        private void InitializeComponent()
        {
            this.txtSummary = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSummary
            // 
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSummary.Location = new System.Drawing.Point(0, 0);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Properties.ReadOnly = true;
            this.txtSummary.Size = new System.Drawing.Size(902, 615);
            this.txtSummary.TabIndex = 0;
            // 
            // PreSummaryPage
            // 
            this.Controls.Add(this.txtSummary);
            this.Name = "PreSummaryPage";
            this.Size = new System.Drawing.Size(902, 615);
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
