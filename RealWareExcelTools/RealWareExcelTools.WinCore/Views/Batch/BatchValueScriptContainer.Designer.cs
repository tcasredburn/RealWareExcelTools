namespace RealWareExcelTools.WinCore.Views.Batch
{
    partial class BatchValueScriptContainer
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.scriptContainer = new DevExpress.XtraEditors.XtraUserControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 49.16F)});
            this.tablePanel1.Controls.Add(this.scriptContainer);
            this.tablePanel1.Controls.Add(this.btnDelete);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(851, 142);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // scriptContainer
            // 
            this.scriptContainer.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.scriptContainer.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.scriptContainer, 1);
            this.scriptContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptContainer.Location = new System.Drawing.Point(117, 16);
            this.scriptContainer.Margin = new System.Windows.Forms.Padding(4);
            this.scriptContainer.Name = "scriptContainer";
            this.tablePanel1.SetRow(this.scriptContainer, 0);
            this.scriptContainer.Size = new System.Drawing.Size(717, 109);
            this.scriptContainer.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.tablePanel1.SetColumn(this.btnDelete, 0);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDelete.ImageOptions.SvgImage = global::RealWareExcelTools.WinCore.Properties.Resources.actions_deletecircled;
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.btnDelete.Location = new System.Drawing.Point(17, 16);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.tablePanel1.SetRow(this.btnDelete, 0);
            this.btnDelete.Size = new System.Drawing.Size(92, 109);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // BatchValueScriptContainer
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BatchValueScriptContainer";
            this.Size = new System.Drawing.Size(851, 142);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.XtraUserControl scriptContainer;
    }
}
