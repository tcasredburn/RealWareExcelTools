using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using RealWare.Core.API;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Forms.Authentication
{
    public partial class LoginToRealWareForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Max time to wait before cancelling with error during authentication.
        /// 
        /// Default is 5 seconds.
        /// </summary>
        public int MaxLoginWaitTime { get; set; } = 5000;

        /// <summary>
        /// Username in the form.
        /// </summary>
        public string Username
        {
            get
            {
                return txtUsername.Text;
            }
            set
            {
                txtUsername.Text = value;
            }
        }

        /// <summary>
        /// API token defined after a successful login attempt.
        /// </summary>
        public string Token { get; private set; } = null;

        private RealWareApi api;
        private CancellationTokenSource cancellationTokenSource;

        public LoginToRealWareForm()
        {
            InitializeComponent();
            toggleLoadingMessage(false);

            //Events
            btnLogin.Click += async (o, e) => await loginToRealwareAsync();
            btnCancel.Click += (o, e) => { this.DialogResult = DialogResult.Cancel; };
        }

        public LoginToRealWareForm(RealWareApi api, string username = null, string password = null) : this()
        {
            this.api = api;
            Username = username;
            this.txtPassword.Text = password;

            // Set cursor focus for easability
            if (string.IsNullOrWhiteSpace(username))
                txtUsername.Focus();
            else
                txtPassword.Focus();
        }

        private async Task loginToRealwareAsync()
        {
            cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(new CancellationToken());

            if (api == null)
                throw new NullReferenceException($"{nameof(api)} cannot be null. Use the constructor for '{nameof(LoginToRealWareForm)}' that defines this.");

            toggleLayoutItemVisibility(layoutControlProgress, true);

            string username = Username;
            string password = txtPassword.Text;

            disableAllInput();

            toggleLoadingMessage(true);
            setLoadingMessageInfo("Connecting to Realware...");

            try
            {
                var authenticateTask = api.AuthenticateAsync(username, password, cancellationTokenSource.Token);
                if (await Task.WhenAny(authenticateTask, Task.Delay(MaxLoginWaitTime)) == authenticateTask)
                {
                    var authenticationResult = await authenticateTask;

                    if (!authenticationResult.Authenticated)
                    {
                        setLoadingMessageError("Username/password for Realware is incorrect.");
                    }
                    else
                    {
                        Token = authenticationResult.AccessToken;
                        setLoadingMessage("Success!", Color.Green);
                        await Task.Delay(1000); // Use async delay to avoid blocking
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    setLoadingMessageError("Timeout error connecting to Realware API. Please retry...");
                    enableAllInput();
                }
            }
            catch (Exception e)
            {
                setLoadingMessageError($"Error connecting to Realware API: {e.Message}");
            }
            finally
            {
                if(!cancellationTokenSource.IsCancellationRequested)
                    enableAllInput();
            }

            if (!cancellationTokenSource.IsCancellationRequested)
                toggleLayoutItemVisibility(layoutControlProgress, false);
        }

        private void disableAllInput()
        {
            toggleTextEdit(txtUsername, false);
            toggleTextEdit(txtPassword, false);
            toggleButton(btnLogin, false);
            toggleButton(btnCancel, false);
        }
        private void enableAllInput()
        {
            toggleTextEdit(txtUsername, true);
            toggleTextEdit(txtPassword, true);
            toggleButton(btnLogin, true);
            toggleButton(btnCancel, true);
        }
        private void toggleTextEdit(TextEdit txt, bool isEnabled)
        {
            if (txt.InvokeRequired)
            {
                txt.Invoke((Action)(() => toggleTextEdit(txt, isEnabled)));
                return;
            }
            txt.Enabled = isEnabled;
        }
        private void toggleButton(SimpleButton btn, bool isEnabled)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke((Action)(() => toggleButton(btn, isEnabled)));
                return;
            }
            btn.Enabled = isEnabled;
        }
        private void toggleLayoutItemVisibility(LayoutControlItem item, bool show)
        {
            if (layoutControl1.InvokeRequired)
            {
                layoutControl1.Invoke((Action)(() => toggleLayoutItemVisibility(item, show)));
                return;
            }
            item.ContentVisible = show;
        }
        private void toggleLoadingMessage(bool show)
        {
            if (layoutControl1.InvokeRequired)
            {
                layoutControl1.Invoke((Action)(() => toggleLoadingMessage(show)));
                return;
            }
            grpMessage.Visibility = show ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void setLoadingMessageInfo(string message)
            => setLoadingMessage(message, Color.Black);
        private void setLoadingMessageError(string message)
            => setLoadingMessage(message, Color.Red);
        private void setLoadingMessage(string message, Color? color = null)
        {
            if (lblMessage.InvokeRequired)
            {
                lblMessage.Invoke((Action)(() => setLoadingMessage(message, color)));
                return;
            }
            lblMessage.Text = message;

            if (color != null)
                lblMessage.Appearance.ForeColor = color.Value;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (cancellationTokenSource != null)
                cancellationTokenSource.Cancel();

            base.OnFormClosing(e);
        }
    }
}