namespace RealWareExcelTools.Modules.Batch.Pages
{
    partial class CreateScriptPage
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
            this.txtScriptLog = new DevExpress.XtraRichEdit.RichEditControl();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnEditScript = new DevExpress.XtraBars.Navigation.NavButton();
            this.errorStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.errorStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtScriptLog
            // 
            this.txtScriptLog.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtScriptLog.Appearance.Text.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScriptLog.Appearance.Text.Options.UseFont = true;
            this.txtScriptLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptLog.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.txtScriptLog.Location = new System.Drawing.Point(0, 40);
            this.txtScriptLog.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtScriptLog.Name = "txtScriptLog";
            this.txtScriptLog.ReadOnly = true;
            this.txtScriptLog.Size = new System.Drawing.Size(917, 719);
            this.txtScriptLog.TabIndex = 0;
            this.txtScriptLog.Text = "Processing...";
            this.txtScriptLog.Views.SimpleView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.Buttons.Add(this.btnEditScript);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.Size = new System.Drawing.Size(917, 40);
            this.tileNavPane1.TabIndex = 1;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // btnEditScript
            // 
            this.btnEditScript.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnEditScript.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnEditScript.ImageOptions.SvgImage = global::RealWareExcelTools.Properties.Resources.edit;
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnEditScript_ElementClick);
            // 
            // errorStatusStrip
            // 
            this.errorStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.errorStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.errorStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.errorStatusStrip.Location = new System.Drawing.Point(0, 733);
            this.errorStatusStrip.Name = "errorStatusStrip";
            this.errorStatusStrip.Size = new System.Drawing.Size(917, 26);
            this.errorStatusStrip.SizingGrip = false;
            this.errorStatusStrip.TabIndex = 2;
            this.errorStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(428, 20);
            this.toolStripStatusLabel1.Text = "File failed to parse. Check script for errors in a tool like VSCode.";
            // 
            // CreateScriptPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorStatusStrip);
            this.Controls.Add(this.txtScriptLog);
            this.Controls.Add(this.tileNavPane1);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "CreateScriptPage";
            this.Size = new System.Drawing.Size(917, 759);
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.errorStatusStrip.ResumeLayout(false);
            this.errorStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl txtScriptLog;
        private System.Windows.Forms.StatusStrip errorStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton btnEditScript;
    }
}
