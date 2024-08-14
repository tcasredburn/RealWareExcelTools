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
            this.listBuilderQueryGrid1 = new RealWareExcelTools.WinCore.Views.ListBuilder.ListBuilderQueryGrid();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.Location = new System.Drawing.Point(11, 812);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(94, 35);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "&Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1191, 812);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            // 
            // listBuilderQueryGrid1
            // 
            this.listBuilderQueryGrid1.Location = new System.Drawing.Point(11, 10);
            this.listBuilderQueryGrid1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBuilderQueryGrid1.Name = "listBuilderQueryGrid1";
            this.listBuilderQueryGrid1.Size = new System.Drawing.Size(1274, 797);
            this.listBuilderQueryGrid1.TabIndex = 3;
            // 
            // ListBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 858);
            this.Controls.Add(this.listBuilderQueryGrid1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.IconOptions.SvgImage = global::RealWareExcelTools.WinCore.Properties.Resources.ico_realware_listbuilder;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ListBuilder Query Selection";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private Views.ListBuilder.ListBuilderQueryGrid listBuilderQueryGrid1;
    }
}