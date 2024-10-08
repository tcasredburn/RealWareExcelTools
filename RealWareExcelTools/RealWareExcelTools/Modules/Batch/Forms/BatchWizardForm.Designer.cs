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
            this.grpModuleType = new DevExpress.XtraEditors.RadioGroup();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.pageSelectOperation = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbBatchAction = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.pageWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSkipFirstPage.Properties)).BeginInit();
            this.pageSelectModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpModuleType.Properties)).BeginInit();
            this.pageSelectOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBatchAction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.pageWelcome);
            this.wizardControl1.Controls.Add(this.pageSelectModule);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.pageSelectOperation);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.ImageOptions.ImageWidth = 216;
            this.wizardControl1.Margin = new System.Windows.Forms.Padding(4);
            this.wizardControl1.MinimumSize = new System.Drawing.Size(117, 123);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.pageWelcome,
            this.pageSelectModule,
            this.pageSelectOperation,
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
            this.pageSelectModule.Controls.Add(this.grpModuleType);
            this.pageSelectModule.DescriptionText = "What type of object would you like to batch?";
            this.pageSelectModule.Margin = new System.Windows.Forms.Padding(4);
            this.pageSelectModule.Name = "pageSelectModule";
            this.pageSelectModule.Size = new System.Drawing.Size(933, 466);
            this.pageSelectModule.Text = "Select Module";
            // 
            // grpModuleType
            // 
            this.grpModuleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpModuleType.Location = new System.Drawing.Point(0, 0);
            this.grpModuleType.Name = "grpModuleType";
            this.grpModuleType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Account"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Appeal"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Permit"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(3)), "Sale")});
            this.grpModuleType.Size = new System.Drawing.Size(933, 466);
            this.grpModuleType.TabIndex = 0;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Margin = new System.Windows.Forms.Padding(4);
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(717, 480);
            // 
            // pageSelectOperation
            // 
            this.pageSelectOperation.Controls.Add(this.layoutControl1);
            this.pageSelectOperation.DescriptionText = "Specify basic settings for inserting, updating, or deleting data.";
            this.pageSelectOperation.Name = "pageSelectOperation";
            this.pageSelectOperation.Size = new System.Drawing.Size(933, 466);
            this.pageSelectOperation.Text = "Operation";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.comboBoxEdit1);
            this.layoutControl1.Controls.Add(this.cmbBatchAction);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(933, 466);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(12, 110);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(452, 22);
            this.comboBoxEdit1.StyleController = this.layoutControl1;
            this.comboBoxEdit1.TabIndex = 4;
            // 
            // cmbBatchAction
            // 
            this.cmbBatchAction.EditValue = "Create new {0}s";
            this.cmbBatchAction.Location = new System.Drawing.Point(12, 31);
            this.cmbBatchAction.Name = "cmbBatchAction";
            this.cmbBatchAction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBatchAction.Properties.Items.AddRange(new object[] {
            "Create new {0}s",
            "Update existing {0}s",
            "Delete existing {0}s"});
            this.cmbBatchAction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBatchAction.Size = new System.Drawing.Size(298, 22);
            this.cmbBatchAction.StyleController = this.layoutControl1;
            this.cmbBatchAction.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(933, 466);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cmbBatchAction;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(302, 45);
            this.layoutControlItem1.Text = "What are you trying to do?";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(152, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(302, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(611, 45);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboBoxEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 79);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(456, 45);
            this.layoutControlItem2.Text = "Spreadsheet";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(152, 16);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(456, 79);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(457, 45);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 124);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(913, 322);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 45);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(913, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            this.pageSelectModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpModuleType.Properties)).EndInit();
            this.pageSelectOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBatchAction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage pageWelcome;
        private DevExpress.XtraWizard.WizardPage pageSelectModule;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.CheckEdit chkSkipFirstPage;
        private DevExpress.XtraWizard.WizardPage pageSelectOperation;
        private DevExpress.XtraEditors.RadioGroup grpModuleType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBatchAction;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}