namespace RealWareExcelTools.WinCore.Views.Settings
{
    partial class SettingsMainView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.settingsRealWareConnectionView1 = new RealWareExcelTools.WinCore.Views.Settings.SettingsRealWareConnectionView();
            this.settingsGeneralView1 = new RealWareExcelTools.WinCore.Views.Settings.SettingsGeneralView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.ShowToolTips = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(1025, 863);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.settingsGeneralView1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(942, 861);
            this.xtraTabPage1.Text = "General";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.settingsRealWareConnectionView1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(942, 861);
            this.xtraTabPage2.Text = "Connection";
            // 
            // settingsRealWareConnectionView1
            // 
            this.settingsRealWareConnectionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsRealWareConnectionView1.Location = new System.Drawing.Point(0, 0);
            this.settingsRealWareConnectionView1.Name = "settingsRealWareConnectionView1";
            this.settingsRealWareConnectionView1.Size = new System.Drawing.Size(942, 861);
            this.settingsRealWareConnectionView1.TabIndex = 0;
            // 
            // settingsGeneralView1
            // 
            this.settingsGeneralView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsGeneralView1.Location = new System.Drawing.Point(0, 0);
            this.settingsGeneralView1.Name = "settingsGeneralView1";
            this.settingsGeneralView1.Size = new System.Drawing.Size(942, 861);
            this.settingsGeneralView1.TabIndex = 0;
            // 
            // SettingsMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "SettingsMainView";
            this.Size = new System.Drawing.Size(1025, 863);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private SettingsRealWareConnectionView settingsRealWareConnectionView1;
        private SettingsGeneralView settingsGeneralView1;
    }
}
