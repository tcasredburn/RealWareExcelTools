namespace RealWareExcelTools.WinCore.Views.Batch.Items
{
    partial class SinglePathBatch
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtName = new DevExpress.XtraEditors.LabelControl();
            this.toggleUseExcelValue = new DevExpress.XtraEditors.ToggleSwitch();
            this.drpValue2 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleUseExcelValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpValue2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Appearance.Options.UseFont = true;
            this.txtName.Location = new System.Drawing.Point(18, 12);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(76, 30);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Quality";
            // 
            // toggleUseExcelValue
            // 
            this.toggleUseExcelValue.Location = new System.Drawing.Point(399, 50);
            this.toggleUseExcelValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toggleUseExcelValue.Name = "toggleUseExcelValue";
            this.toggleUseExcelValue.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toggleUseExcelValue.Properties.Appearance.Options.UseFont = true;
            this.toggleUseExcelValue.Properties.OffText = "Use static value";
            this.toggleUseExcelValue.Properties.OnText = "Use Excel value";
            this.toggleUseExcelValue.Size = new System.Drawing.Size(261, 32);
            this.toggleUseExcelValue.TabIndex = 2;
            this.toggleUseExcelValue.Toggled += new System.EventHandler(this.toggleUseExcelValue_Toggled);
            // 
            // drpValue2
            // 
            this.drpValue2.Location = new System.Drawing.Point(26, 49);
            this.drpValue2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drpValue2.Name = "drpValue2";
            this.drpValue2.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.drpValue2.Properties.Appearance.Options.UseFont = true;
            this.drpValue2.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.drpValue2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 50, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.drpValue2.Properties.NullText = "(Select a value)";
            this.drpValue2.Size = new System.Drawing.Size(368, 34);
            this.drpValue2.TabIndex = 3;
            // 
            // SinglePathBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drpValue2);
            this.Controls.Add(this.toggleUseExcelValue);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(674, 106);
            this.Name = "SinglePathBatch";
            this.Size = new System.Drawing.Size(674, 106);
            ((System.ComponentModel.ISupportInitialize)(this.toggleUseExcelValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpValue2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl txtName;
        private DevExpress.XtraEditors.ToggleSwitch toggleUseExcelValue;
        private DevExpress.XtraEditors.LookUpEdit drpValue2;
    }
}
