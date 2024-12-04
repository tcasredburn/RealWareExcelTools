namespace RealWareExcelTools.WinCore.Forms
{
    partial class ListBuilderForm
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
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.importProgressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.listBuilderQueryGrid1 = new RealWareExcelTools.WinCore.Views.ListBuilder.ListBuilderQueryGrid();
            this.chkReplaceCurrentSheet = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReplaceCurrentSheet.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(13, 1125);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 43);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "&Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1499, 1125);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 43);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            // 
            // importProgressPanel
            // 
            this.importProgressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importProgressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.importProgressPanel.Appearance.Options.UseBackColor = true;
            this.importProgressPanel.Caption = "Processing query";
            this.importProgressPanel.Description = "Please wait...";
            this.importProgressPanel.Location = new System.Drawing.Point(135, 1111);
            this.importProgressPanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.importProgressPanel.Name = "importProgressPanel";
            this.importProgressPanel.Size = new System.Drawing.Size(246, 66);
            this.importProgressPanel.TabIndex = 4;
            this.importProgressPanel.Text = "importProgressPanel";
            // 
            // listBuilderQueryGrid1
            // 
            this.listBuilderQueryGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBuilderQueryGrid1.Location = new System.Drawing.Point(13, 12);
            this.listBuilderQueryGrid1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listBuilderQueryGrid1.Name = "listBuilderQueryGrid1";
            this.listBuilderQueryGrid1.Size = new System.Drawing.Size(1595, 1077);
            this.listBuilderQueryGrid1.TabIndex = 3;
            // 
            // chkReplaceCurrentSheet
            // 
            this.chkReplaceCurrentSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReplaceCurrentSheet.Location = new System.Drawing.Point(13, 1088);
            this.chkReplaceCurrentSheet.Name = "chkReplaceCurrentSheet";
            this.chkReplaceCurrentSheet.Properties.Caption = "Replace Current Sheet";
            this.chkReplaceCurrentSheet.Size = new System.Drawing.Size(164, 24);
            this.chkReplaceCurrentSheet.TabIndex = 5;
            // 
            // ListBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 1182);
            this.Controls.Add(this.chkReplaceCurrentSheet);
            this.Controls.Add(this.importProgressPanel);
            this.Controls.Add(this.listBuilderQueryGrid1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.IconOptions.SvgImage = global::RealWareExcelTools.WinCore.Properties.Resources.ico_realware_listbuilder;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "ListBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ListBuilder Query Selection";
            ((System.ComponentModel.ISupportInitialize)(this.chkReplaceCurrentSheet.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private Views.ListBuilder.ListBuilderQueryGrid listBuilderQueryGrid1;
        private DevExpress.XtraWaitForm.ProgressPanel importProgressPanel;
        private DevExpress.XtraEditors.CheckEdit chkReplaceCurrentSheet;
    }
}