namespace RealWareExcelTools.Modules.Batch.Pages
{
    partial class ProcessingScriptPage
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
            this.SuspendLayout();
            // 
            // txtScriptLog
            // 
            this.txtScriptLog.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtScriptLog.Appearance.Text.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScriptLog.Appearance.Text.Options.UseFont = true;
            this.txtScriptLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScriptLog.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.txtScriptLog.Location = new System.Drawing.Point(0, 0);
            this.txtScriptLog.Name = "txtScriptLog";
            this.txtScriptLog.Size = new System.Drawing.Size(917, 759);
            this.txtScriptLog.TabIndex = 0;
            this.txtScriptLog.Text = "Processing...";
            this.txtScriptLog.Views.SimpleView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // ProcessingScriptPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtScriptLog);
            this.Name = "ProcessingScriptPage";
            this.Size = new System.Drawing.Size(917, 759);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl txtScriptLog;
    }
}
