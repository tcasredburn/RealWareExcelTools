using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using RealWareExcelTools.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Views.Settings
{
    public partial class SettingsMainView : DevExpress.XtraEditors.XtraUserControl, ISettingsView
    {
        public string OnSaveErrorMessage { get; private set; }

        List<ISettingsView> settingViews;

        public SettingsMainView()
        {
            InitializeComponent();

            getAllISettingViews();
        }

        private void getAllISettingViews()
        {
            settingViews = new List<ISettingsView>();

            foreach (XtraTabPage page in xtraTabControl1.TabPages)
            {
                foreach (var control in page.Controls)
                {
                    if (control is ISettingsView)
                    {
                        settingViews.Add((ISettingsView)control);
                    }
                }
            }
        }

        public void OnLoadSettings(AddinSettings settings)
        {
            foreach(var view in settingViews)
                view.OnLoadSettings(settings);
        }

        public bool OnSaveSettings(ref AddinSettings settings)
        {
            bool result = true;

            foreach (var view in settingViews)
            {
                if (!view.OnSaveSettings(ref settings))
                {
                    OnSaveErrorMessage = view.OnSaveErrorMessage;
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
