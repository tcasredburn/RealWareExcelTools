namespace RealWareExcelTools.Modules.Batch.Pages
{
    partial class PreValidationPage
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
            this.progressBarControl3 = new RealWareExcelTools.WinCore.Views.Processing.ProgressBarControl();
            this.progressBarControl2 = new RealWareExcelTools.WinCore.Views.Processing.ProgressBarControl();
            this.progressBarControl1 = new RealWareExcelTools.WinCore.Views.Processing.ProgressBarControl();
            this.SuspendLayout();
            // 
            // progressBarControl3
            // 
            this.progressBarControl3.Location = new System.Drawing.Point(85, 296);
            this.progressBarControl3.Name = "progressBarControl3";
            this.progressBarControl3.Size = new System.Drawing.Size(620, 111);
            this.progressBarControl3.TabIndex = 2;
            // 
            // progressBarControl2
            // 
            this.progressBarControl2.Location = new System.Drawing.Point(85, 167);
            this.progressBarControl2.Name = "progressBarControl2";
            this.progressBarControl2.Size = new System.Drawing.Size(620, 111);
            this.progressBarControl2.TabIndex = 1;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(85, 36);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(620, 111);
            this.progressBarControl1.TabIndex = 0;
            // 
            // PreValidationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarControl3);
            this.Controls.Add(this.progressBarControl2);
            this.Controls.Add(this.progressBarControl1);
            this.Name = "PreValidationPage";
            this.Size = new System.Drawing.Size(862, 530);
            this.ResumeLayout(false);

        }

        #endregion

        private WinCore.Views.Processing.ProgressBarControl progressBarControl1;
        private WinCore.Views.Processing.ProgressBarControl progressBarControl2;
        private WinCore.Views.Processing.ProgressBarControl progressBarControl3;
    }
}
