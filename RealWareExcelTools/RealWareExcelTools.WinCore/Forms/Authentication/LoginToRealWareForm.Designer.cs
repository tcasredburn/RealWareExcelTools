namespace RealWareExcelTools.WinCore.Forms.Authentication
{
    partial class LoginToRealWareForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.grpMessage = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlProgress = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.lblMessage);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnLogin);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.progressPanel1);
            this.layoutControl1.Controls.Add(this.txtUsername);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(567, 287);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.lblMessage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Location = new System.Drawing.Point(88, 149);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(454, 32);
            this.lblMessage.StyleController = this.layoutControl1;
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Logging into realware";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(400, 233);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 27);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(25, 233);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(150, 27);
            this.btnLogin.StyleController = this.layoutControl1;
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "LOGIN";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(95, 101);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(447, 38);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 8;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Location = new System.Drawing.Point(25, 143);
            this.progressPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.ShowCaption = false;
            this.progressPanel1.ShowDescription = false;
            this.progressPanel1.Size = new System.Drawing.Size(59, 45);
            this.progressPanel1.StyleController = this.layoutControl1;
            this.progressPanel1.TabIndex = 7;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(95, 59);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Size = new System.Drawing.Size(447, 38);
            this.txtUsername.StyleController = this.layoutControl1;
            this.txtUsername.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.simpleLabelItem1,
            this.emptySpaceItem4,
            this.grpMessage});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(23, 23, 25, 25);
            this.Root.Size = new System.Drawing.Size(567, 287);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtUsername;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(521, 42);
            this.layoutControlItem1.Text = "Username";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPassword;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(521, 42);
            this.layoutControlItem3.Text = "Password";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(58, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnLogin;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 206);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(154, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(375, 206);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(146, 31);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(154, 206);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(221, 31);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 165);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(521, 41);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(521, 20);
            this.simpleLabelItem1.Text = "Please login to RealWare.";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(147, 16);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 20);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(521, 12);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // grpMessage
            // 
            this.grpMessage.GroupBordersVisible = false;
            this.grpMessage.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlProgress,
            this.layoutControlItem6});
            this.grpMessage.Location = new System.Drawing.Point(0, 116);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(521, 49);
            // 
            // layoutControlProgress
            // 
            this.layoutControlProgress.Control = this.progressPanel1;
            this.layoutControlProgress.Location = new System.Drawing.Point(0, 0);
            this.layoutControlProgress.MaxSize = new System.Drawing.Size(63, 49);
            this.layoutControlProgress.MinSize = new System.Drawing.Size(63, 49);
            this.layoutControlProgress.Name = "layoutControlProgress";
            this.layoutControlProgress.Size = new System.Drawing.Size(63, 49);
            this.layoutControlProgress.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlProgress.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlProgress.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lblMessage;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.layoutControlItem6.Location = new System.Drawing.Point(63, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(458, 49);
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            this.layoutControlItem6.TrimClientAreaToControl = false;
            // 
            // LoginToRealWareForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(567, 287);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = global::RealWareExcelTools.WinCore.Properties.Resources.security_key;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginToRealWareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RealWare Authentication";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlGroup grpMessage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlProgress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}