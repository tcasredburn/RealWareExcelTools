namespace RealWareExcelTools.Modules.Batch.Forms
{
    partial class BatchWizardForm
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
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.pageWelcome = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.chkSkipFirstPage = new DevExpress.XtraEditors.CheckEdit();
            this.pageSelectModule = new DevExpress.XtraWizard.WizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.pageSelectOperation = new DevExpress.XtraWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.pageWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSkipFirstPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.pageWelcome);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.ImageOptions.ImageWidth = 216;
            this.wizardControl1.Margin = new System.Windows.Forms.Padding(4);
            this.wizardControl1.MinimumSize = new System.Drawing.Size(117, 123);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.pageWelcome,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(973, 644);
            // 
            // pageWelcome
            // 
            this.pageWelcome.Controls.Add(this.chkSkipFirstPage);
            this.pageWelcome.IntroductionText = "This wizard simplifies the batching of basic account, permit, sale, or appeal inf" +
    "ormation using the RealWare API.";
            this.pageWelcome.Margin = new System.Windows.Forms.Padding(4);
            this.pageWelcome.Name = "pageWelcome";
            this.pageWelcome.Size = new System.Drawing.Size(717, 480);
            this.pageWelcome.Text = "Welcome to the RealWare batch wizard";
            // 
            // chkSkipFirstPage
            // 
            this.chkSkipFirstPage.Location = new System.Drawing.Point(6, 415);
            this.chkSkipFirstPage.Margin = new System.Windows.Forms.Padding(4);
            this.chkSkipFirstPage.Name = "chkSkipFirstPage";
            this.chkSkipFirstPage.Properties.Caption = "Skip this page";
            this.chkSkipFirstPage.Size = new System.Drawing.Size(204, 24);
            this.chkSkipFirstPage.TabIndex = 0;
            this.chkSkipFirstPage.CheckedChanged += new System.EventHandler(this.chkSkipFirstPage_CheckedChanged);
            // 
            // pageSelectModule
            // 
            this.pageSelectModule.DescriptionText = "What type of object would you like to batch?";
            this.pageSelectModule.Margin = new System.Windows.Forms.Padding(4);
            this.pageSelectModule.Name = "pageSelectModule";
            this.pageSelectModule.Size = new System.Drawing.Size(933, 466);
            this.pageSelectModule.Text = "";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Margin = new System.Windows.Forms.Padding(4);
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(717, 480);
            // 
            // pageSelectOperation
            // 
            this.pageSelectOperation.DescriptionText = "Specify basic settings for inserting, updating, or deleting data.";
            this.pageSelectOperation.Name = "pageSelectOperation";
            this.pageSelectOperation.Size = new System.Drawing.Size(933, 466);
            this.pageSelectOperation.Text = "";
            // 
            // BatchWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 644);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RealWare Batch Wizard";
            this.Load += new System.EventHandler(this.BatchWizardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.pageWelcome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSkipFirstPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage pageWelcome;
        private DevExpress.XtraWizard.WizardPage pageSelectModule;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.CheckEdit chkSkipFirstPage;
        private DevExpress.XtraWizard.WizardPage pageSelectOperation;
    }
}