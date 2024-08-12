using Microsoft.Office.Core;
using RealWareExcelTools.Properties;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RealWareExcelTools.Ribbon
{
    [ComVisible(true)]
    public class RealWareRibbon : IRibbonExtensibility
    {
        private bool isConnectedToRealWare = false;

        private Microsoft.Office.Core.IRibbonUI ribbon;

        private readonly ThisAddIn _addIn;

        public RealWareRibbon(ThisAddIn addIn)
        {
            _addIn = addIn;
        }

        public void OnRibbonLoad(Microsoft.Office.Core.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }


        #region Ribbon XML
        public string GetCustomUI(string RibbonID)
            => getResourceText("RealWareExcelTools.Ribbon.RealWareRibbon.xml");

        private string getResourceText(string resourceName)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return null;
                }
                using (var reader = new System.IO.StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion

        #region ConnectToRealWare
        public void OnConnectToRealWareClick(IRibbonControl control, bool isPressed)
        {
            isConnectedToRealWare = isPressed;

            ribbon.Invalidate();
        }

        public Bitmap GetConnectToRealWareIcon(IRibbonControl control)
            => isConnectedToRealWare ? Resources.ico_realware_connection_valid_128x128
                : Resources.ico_realware_connection_invalid_128x128;

        public string GetConnectToRealWareLabel(IRibbonControl control)
            => isConnectedToRealWare ? "Disconnect from RealWare"
                : "Connect to RealWare";

        public bool GetConnectToRealWarePressed(IRibbonControl control)
            => isConnectedToRealWare;
        #endregion

        #region ImportFromListBuilder
        public void OnImportFromRealWareClick(IRibbonControl control)
        {
            MessageBox.Show("TODO: Importing data from RealWare");
        }

        public Bitmap GetImportFromListBuilderImage(IRibbonControl control)
            => Resources.ico_realware_listbuilder_128x128;

        public bool GetImportFromListBuilderEnabled(IRibbonControl control)
            => isConnectedToRealWare;
        #endregion

        #region BatchAccounts
        public void OnBatchAccountsClick(IRibbonControl control)
        {
            MessageBox.Show("TODO: Batch data wizard for RealWare");
        }

        public Bitmap GetBatchAccountsImage(IRibbonControl control)
            => Resources.ico_realware_batch_128x128;

        public bool GetBatchAccountsEnabled(IRibbonControl control)
            => isConnectedToRealWare;
        #endregion

        #region BatchAccounts
        public void OnSettingsClick(IRibbonControl control)
        {
            if(new WinCore.Forms.SettingsForm().ShowDialog() == DialogResult.OK)
            {
                // TODO: Save settings
            }
        }

        public Bitmap GetSettingsImage(IRibbonControl control)
            => Resources.ico_realware_settings_128x128;
        #endregion
    }
}
