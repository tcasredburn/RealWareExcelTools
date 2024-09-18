namespace RealWareExcelTools.WinCore.Forms
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.moduleContainer = new DevExpress.XtraEditors.XtraUserControl();
            this.btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // moduleContainer
            // 
            this.moduleContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moduleContainer.Location = new System.Drawing.Point(10, 10);
            this.moduleContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moduleContainer.Name = "moduleContainer";
            this.moduleContainer.Size = new System.Drawing.Size(825, 513);
            this.moduleContainer.TabIndex = 0;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(10, 527);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(115, 35);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "&Save";
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(720, 527);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 572);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.moduleContainer);
            this.HelpButton = true;
            this.IconOptions.SvgImage = global::RealWareExcelTools.WinCore.Properties.Resources.ico_realware_settings;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.SurfaceMaterial = DevExpress.XtraEditors.SurfaceMaterial.Acrylic;
            this.Text = "RealWare Excel Tools Settings";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraUserControl moduleContainer;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}