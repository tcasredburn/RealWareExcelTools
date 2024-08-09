﻿using Microsoft.Office.Core;
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

            ribbon.InvalidateControl(control.Id);
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
            => true;
        #endregion
    }
}
