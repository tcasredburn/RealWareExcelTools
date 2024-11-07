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
            this.drpValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtName = new DevExpress.XtraEditors.LabelControl();
            this.toggleUseExcelValue = new DevExpress.XtraEditors.ToggleSwitch();
            this.drpValue2 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.drpValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleUseExcelValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpValue2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // drpValue
            // 
            this.drpValue.Location = new System.Drawing.Point(58, 58);
            this.drpValue.Name = "drpValue";
            this.drpValue.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.drpValue.Properties.Appearance.Options.UseFont = true;
            this.drpValue.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.drpValue.Properties.AppearanceDropDown.Options.UseFont = true;
            this.drpValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpValue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpValue.Size = new System.Drawing.Size(429, 44);
            this.drpValue.TabIndex = 0;
            this.drpValue.Visible = false;
            this.drpValue.TextChanged += new System.EventHandler(this.drpValue_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Appearance.Options.UseFont = true;
            this.txtName.Location = new System.Drawing.Point(21, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(94, 37);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Quality";
            // 
            // toggleUseExcelValue
            // 
            this.toggleUseExcelValue.Location = new System.Drawing.Point(493, 61);
            this.toggleUseExcelValue.Name = "toggleUseExcelValue";
            this.toggleUseExcelValue.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.toggleUseExcelValue.Properties.Appearance.Options.UseFont = true;
            this.toggleUseExcelValue.Properties.OffText = "Use static value";
            this.toggleUseExcelValue.Properties.OnText = "Use Excel value";
            this.toggleUseExcelValue.Size = new System.Drawing.Size(420, 41);
            this.toggleUseExcelValue.TabIndex = 2;
            this.toggleUseExcelValue.Toggled += new System.EventHandler(this.toggleUseExcelValue_Toggled);
            // 
            // drpValue2
            // 
            this.drpValue2.Location = new System.Drawing.Point(58, 60);
            this.drpValue2.Name = "drpValue2";
            this.drpValue2.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.drpValue2.Properties.Appearance.Options.UseFont = true;
            this.drpValue2.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.drpValue2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 50, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.drpValue2.Properties.NullText = "(Select a value)";
            this.drpValue2.Size = new System.Drawing.Size(429, 44);
            this.drpValue2.TabIndex = 3;
            // 
            // SinglePathBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drpValue2);
            this.Controls.Add(this.toggleUseExcelValue);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.drpValue);
            this.Name = "SinglePathBatch";
            this.Size = new System.Drawing.Size(1004, 151);
            ((System.ComponentModel.ISupportInitialize)(this.drpValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleUseExcelValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpValue2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit drpValue;
        private DevExpress.XtraEditors.LabelControl txtName;
        private DevExpress.XtraEditors.ToggleSwitch toggleUseExcelValue;
        private DevExpress.XtraEditors.LookUpEdit drpValue2;
    }
}
