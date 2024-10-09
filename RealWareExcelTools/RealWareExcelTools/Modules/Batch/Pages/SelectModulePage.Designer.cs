namespace RealWareExcelTools.Modules.Batch.Pages
{
    partial class SelectModulePage
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
            this.grpModuleType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.grpModuleType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpModuleType
            // 
            this.grpModuleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpModuleType.Location = new System.Drawing.Point(0, 0);
            this.grpModuleType.Name = "grpModuleType";
            this.grpModuleType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Account"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Appeal"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Improvement"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "Permit"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(4)), "Sale")});
            this.grpModuleType.Size = new System.Drawing.Size(667, 470);
            this.grpModuleType.TabIndex = 1;
            // 
            // SelectModulePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpModuleType);
            this.Name = "SelectModulePage";
            this.Size = new System.Drawing.Size(667, 470);
            ((System.ComponentModel.ISupportInitialize)(this.grpModuleType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup grpModuleType;
    }
}
