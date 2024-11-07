namespace RealWareExcelTools.WinCore.Views.Processing
{
    partial class ProgressBarControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBarControl));
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.statusController = new DevExpress.XtraTab.XtraTabControl();
            this.tabLoading = new DevExpress.XtraTab.XtraTabPage();
            this.tabError = new DevExpress.XtraTab.XtraTabPage();
            this.tabSuccess = new DevExpress.XtraTab.XtraTabPage();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.lblErrorMessage = new DevExpress.XtraEditors.LabelControl();
            this.lblErrorHeader = new DevExpress.XtraEditors.LabelControl();
            this.lblSuccessMessage = new DevExpress.XtraEditors.LabelControl();
            this.lblSuccessHeader = new DevExpress.XtraEditors.LabelControl();
            this.svgImageBox2 = new DevExpress.XtraEditors.SvgImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusController)).BeginInit();
            this.statusController.SuspendLayout();
            this.tabLoading.SuspendLayout();
            this.tabError.SuspendLayout();
            this.tabSuccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Caption = "Processing connection...";
            this.progressPanel1.Description = "Please wait...";
            this.progressPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel1.Location = new System.Drawing.Point(0, 0);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(466, 81);
            this.progressPanel1.TabIndex = 0;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // statusController
            // 
            this.statusController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusController.Location = new System.Drawing.Point(0, 0);
            this.statusController.Name = "statusController";
            this.statusController.SelectedTabPage = this.tabLoading;
            this.statusController.Size = new System.Drawing.Size(468, 111);
            this.statusController.TabIndex = 1;
            this.statusController.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabLoading,
            this.tabError,
            this.tabSuccess});
            // 
            // tabLoading
            // 
            this.tabLoading.Controls.Add(this.progressPanel1);
            this.tabLoading.Name = "tabLoading";
            this.tabLoading.Size = new System.Drawing.Size(466, 81);
            this.tabLoading.Text = "Status=Loading";
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.lblErrorMessage);
            this.tabError.Controls.Add(this.lblErrorHeader);
            this.tabError.Controls.Add(this.svgImageBox1);
            this.tabError.Name = "tabError";
            this.tabError.Size = new System.Drawing.Size(466, 81);
            this.tabError.Text = "Status=Error";
            // 
            // tabSuccess
            // 
            this.tabSuccess.Controls.Add(this.svgImageBox2);
            this.tabSuccess.Controls.Add(this.lblSuccessMessage);
            this.tabSuccess.Controls.Add(this.lblSuccessHeader);
            this.tabSuccess.Name = "tabSuccess";
            this.tabSuccess.Size = new System.Drawing.Size(466, 81);
            this.tabSuccess.Text = "Status=Success";
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(3, 3);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(79, 76);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 0;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Location = new System.Drawing.Point(88, 45);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(75, 16);
            this.lblErrorMessage.TabIndex = 4;
            this.lblErrorMessage.Text = "labelControl3";
            // 
            // lblErrorHeader
            // 
            this.lblErrorHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorHeader.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErrorHeader.Appearance.Options.UseFont = true;
            this.lblErrorHeader.Appearance.Options.UseForeColor = true;
            this.lblErrorHeader.Location = new System.Drawing.Point(88, 21);
            this.lblErrorHeader.Name = "lblErrorHeader";
            this.lblErrorHeader.Size = new System.Drawing.Size(102, 18);
            this.lblErrorHeader.TabIndex = 3;
            this.lblErrorHeader.Text = "labelControl4";
            // 
            // lblSuccessMessage
            // 
            this.lblSuccessMessage.Location = new System.Drawing.Point(88, 44);
            this.lblSuccessMessage.Name = "lblSuccessMessage";
            this.lblSuccessMessage.Size = new System.Drawing.Size(75, 16);
            this.lblSuccessMessage.TabIndex = 6;
            this.lblSuccessMessage.Text = "labelControl5";
            // 
            // lblSuccessHeader
            // 
            this.lblSuccessHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessHeader.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSuccessHeader.Appearance.Options.UseFont = true;
            this.lblSuccessHeader.Appearance.Options.UseForeColor = true;
            this.lblSuccessHeader.Location = new System.Drawing.Point(88, 20);
            this.lblSuccessHeader.Name = "lblSuccessHeader";
            this.lblSuccessHeader.Size = new System.Drawing.Size(102, 18);
            this.lblSuccessHeader.TabIndex = 5;
            this.lblSuccessHeader.Text = "labelControl6";
            // 
            // svgImageBox2
            // 
            this.svgImageBox2.Location = new System.Drawing.Point(3, 3);
            this.svgImageBox2.Name = "svgImageBox2";
            this.svgImageBox2.Size = new System.Drawing.Size(79, 76);
            this.svgImageBox2.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Zoom;
            this.svgImageBox2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox2.SvgImage")));
            this.svgImageBox2.TabIndex = 7;
            this.svgImageBox2.Text = "svgImageBox2";
            // 
            // ProgressBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusController);
            this.Name = "ProgressBarControl";
            this.Size = new System.Drawing.Size(468, 111);
            ((System.ComponentModel.ISupportInitialize)(this.statusController)).EndInit();
            this.statusController.ResumeLayout(false);
            this.tabLoading.ResumeLayout(false);
            this.tabError.ResumeLayout(false);
            this.tabError.PerformLayout();
            this.tabSuccess.ResumeLayout(false);
            this.tabSuccess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraTab.XtraTabControl statusController;
        private DevExpress.XtraTab.XtraTabPage tabLoading;
        private DevExpress.XtraTab.XtraTabPage tabError;
        private DevExpress.XtraEditors.LabelControl lblErrorMessage;
        private DevExpress.XtraEditors.LabelControl lblErrorHeader;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private DevExpress.XtraTab.XtraTabPage tabSuccess;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox2;
        private DevExpress.XtraEditors.LabelControl lblSuccessMessage;
        private DevExpress.XtraEditors.LabelControl lblSuccessHeader;
    }
}
