using DevExpress.XtraWizard;
using System;

namespace RealWareExcelTools.Modules.Batch.Pages
{
    public class PreSummaryPage : BaseBatchWizardPage, IRealWareBatchWizardPage
    {
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TrackBarControl trackBarThreads;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TrackBarControl trackBarRetryCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.MemoEdit txtSummary;

        public string PageTitle => "Script Summary";

        public string PageDescription => "Verify everything looks correct before running through RealWare.";

        public PreSummaryPage()
        {
            InitializeComponent();
        }

        public void OnSavePage() 
        { 
            Context.Script.ThreadCount = trackBarThreads.Value;
            Context.Script.RetryCount = trackBarRetryCount.Value;
            Context.Script.RetryDelay = Convert.ToInt32(spinEdit1.Value * 1000);
        }

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
            string result = "";

            foreach (var item in Context.Script.MappingInfo)
            {
                // Determine the data source name separately
                string dataSourceName = item.DataSourceType == WinCore.Models.Batch.DataSourceType.Excel
                    ? $"({item.DataSourceName})"
                    : "item.DataSourceName";

                // Build the result string without newlines in the interpolated string
                result += $"    {item.RealWareColumnName} = {dataSourceName}" + Environment.NewLine;

            }

            return result;
        }

        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel2 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel3 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel4 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel5 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel6 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel7 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel8 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel9 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel10 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel11 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel12 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel13 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel14 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel15 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel16 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel17 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel18 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel19 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel20 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel21 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel22 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            this.txtSummary = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.trackBarRetryCount = new DevExpress.XtraEditors.TrackBarControl();
            this.trackBarThreads = new DevExpress.XtraEditors.TrackBarControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRetryCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRetryCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(24, 50);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Properties.ReadOnly = true;
            this.txtSummary.Size = new System.Drawing.Size(854, 346);
            this.txtSummary.StyleController = this.layoutControl1;
            this.txtSummary.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.spinEdit1);
            this.layoutControl1.Controls.Add(this.trackBarRetryCount);
            this.layoutControl1.Controls.Add(this.trackBarThreads);
            this.layoutControl1.Controls.Add(this.txtSummary);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(902, 615);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(797, 559);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.MaskSettings.Set("mask", "f");
            this.spinEdit1.Properties.MaskSettings.Set("autoHideDecimalSeparator", false);
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            this.spinEdit1.Properties.UseMaskAsDisplayFormat = true;
            this.spinEdit1.Size = new System.Drawing.Size(81, 22);
            this.spinEdit1.StyleController = this.layoutControl1;
            this.spinEdit1.TabIndex = 7;
            this.spinEdit1.EditValueChanged += new System.EventHandler(this.spinEdit1_EditValueChanged);
            // 
            // trackBarRetryCount
            // 
            this.trackBarRetryCount.EditValue = 3;
            this.trackBarRetryCount.Location = new System.Drawing.Point(631, 469);
            this.trackBarRetryCount.Name = "trackBarRetryCount";
            this.trackBarRetryCount.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trackBarRetryCount.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "0";
            trackBarLabel2.Label = "1";
            trackBarLabel2.Value = 1;
            trackBarLabel3.Label = "2";
            trackBarLabel3.Value = 2;
            trackBarLabel4.Label = "3";
            trackBarLabel4.Value = 3;
            trackBarLabel5.Label = "4";
            trackBarLabel5.Value = 4;
            trackBarLabel6.Label = "5";
            trackBarLabel6.Value = 5;
            this.trackBarRetryCount.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1,
            trackBarLabel2,
            trackBarLabel3,
            trackBarLabel4,
            trackBarLabel5,
            trackBarLabel6});
            this.trackBarRetryCount.Properties.Maximum = 5;
            this.trackBarRetryCount.Properties.ShowLabels = true;
            this.trackBarRetryCount.Size = new System.Drawing.Size(247, 86);
            this.trackBarRetryCount.StyleController = this.layoutControl1;
            this.trackBarRetryCount.TabIndex = 6;
            this.trackBarRetryCount.Value = 3;
            // 
            // trackBarThreads
            // 
            this.trackBarThreads.EditValue = 1;
            this.trackBarThreads.Location = new System.Drawing.Point(24, 469);
            this.trackBarThreads.Name = "trackBarThreads";
            this.trackBarThreads.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trackBarThreads.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel7.Label = "1";
            trackBarLabel7.Value = 1;
            trackBarLabel8.Label = "2";
            trackBarLabel8.Value = 2;
            trackBarLabel9.Label = "3";
            trackBarLabel9.Value = 3;
            trackBarLabel10.Label = "4";
            trackBarLabel10.Value = 4;
            trackBarLabel11.Label = "5";
            trackBarLabel11.Value = 5;
            trackBarLabel12.Label = "6";
            trackBarLabel12.Value = 6;
            trackBarLabel13.Label = "7";
            trackBarLabel13.Value = 7;
            trackBarLabel14.Label = "8";
            trackBarLabel14.Value = 8;
            trackBarLabel15.Label = "9";
            trackBarLabel15.Value = 9;
            trackBarLabel16.Label = "10";
            trackBarLabel16.Value = 10;
            trackBarLabel17.Label = "11";
            trackBarLabel17.Value = 11;
            trackBarLabel18.Label = "12";
            trackBarLabel18.Value = 12;
            trackBarLabel19.Label = "13";
            trackBarLabel19.Value = 13;
            trackBarLabel20.Label = "14";
            trackBarLabel20.Value = 14;
            trackBarLabel21.Label = "15";
            trackBarLabel21.Value = 15;
            trackBarLabel22.Label = "16";
            trackBarLabel22.Value = 16;
            this.trackBarThreads.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel7,
            trackBarLabel8,
            trackBarLabel9,
            trackBarLabel10,
            trackBarLabel11,
            trackBarLabel12,
            trackBarLabel13,
            trackBarLabel14,
            trackBarLabel15,
            trackBarLabel16,
            trackBarLabel17,
            trackBarLabel18,
            trackBarLabel19,
            trackBarLabel20,
            trackBarLabel21,
            trackBarLabel22});
            this.trackBarThreads.Properties.Maximum = 16;
            this.trackBarThreads.Properties.Minimum = 1;
            this.trackBarThreads.Properties.ShowLabels = true;
            this.trackBarThreads.Size = new System.Drawing.Size(453, 86);
            this.trackBarThreads.StyleController = this.layoutControl1;
            this.trackBarThreads.TabIndex = 5;
            this.trackBarThreads.Value = 1;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(902, 615);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(882, 400);
            this.layoutControlGroup1.Text = "Summary";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSummary;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(858, 350);
            this.layoutControlItem1.Text = "Summary";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 400);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(882, 195);
            this.layoutControlGroup2.Text = "Process Settings";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(514, 135);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(344, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.trackBarThreads;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(457, 145);
            this.layoutControlItem3.Text = "Number of Threads";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(247, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.trackBarRetryCount;
            this.layoutControlItem2.Location = new System.Drawing.Point(607, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(251, 109);
            this.layoutControlItem2.Text = "Retry Attempts";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(247, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.spinEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(514, 109);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(344, 26);
            this.layoutControlItem4.Text = "Delay between Retry Attempts (in seconds)";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(247, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(457, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(57, 145);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(514, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(93, 109);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // PreSummaryPage
            // 
            this.Controls.Add(this.layoutControl1);
            this.Name = "PreSummaryPage";
            this.Size = new System.Drawing.Size(902, 615);
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRetryCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRetryCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
