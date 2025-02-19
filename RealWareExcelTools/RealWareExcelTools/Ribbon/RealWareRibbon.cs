﻿using Microsoft.Office.Core;
using RealWareExcelTools.Modules;
using RealWareExcelTools.Modules.Batch.Forms;
using RealWareExcelTools.Modules.Batch.Models;
using RealWareExcelTools.Properties;
using RealWareExcelTools.WinCore.Forms;
using RealWareExcelTools.WinCore.Validation;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RealWareExcelTools.Ribbon
{
    // Callback methods:
    // https://learn.microsoft.com/en-us/openspecs/office_standards/ms-customui/ec42bfd0-149c-495b-895c-3bc708b8a149

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

            // If the user has set the connection to RealWare to be automatic, then connect on startup
            if(_addIn.Settings.RealWareApiConnectionSettings.ConnectOnExcelStartup)
            {
                if (string.IsNullOrEmpty(_addIn.Settings.RealWareApiConnectionSettings.Url)
                    || string.IsNullOrEmpty(_addIn.Settings.RealWareApiConnectionSettings.Token)
                    || string.IsNullOrEmpty(_addIn.Settings.RealWareApiConnectionSettings.RealWareUserName))
                    return;

                var validator = validateConnectionToRealWare(false);

                if (!validator.ConnectionIsValid)
                    return;

                
                if (isConnectedToRealWare)
                {
                    // Save settings if valid
                    _addIn.SetRealWareApiConnection(validator.GetRealWareApiConnection());

                    // Refresh the ribbon connected button
                    this.ribbon.Invalidate();
                }
            }
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
            if (isConnectedToRealWare)
            {
                isConnectedToRealWare = false;
            }
            else
            {
                var validator = validateConnectionToRealWare(true);

                _addIn.SetRealWareApiConnection(validator.GetRealWareApiConnection());
                _addIn.Settings.RealWareApiConnectionSettings.Token = validator.ApiToken;
                _addIn.Settings.RealWareApiConnectionSettings.RealWareUserName = validator.RealWareLoginName;
                _addIn.SaveSettings(_addIn.Settings);
            }
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

        private ConnectToRealWareValidator validateConnectionToRealWare(bool showForm)
        {
            var validator = new ConnectToRealWareValidator(
                    _addIn.Settings.RealWareApiConnectionSettings.Url,
                    _addIn.Settings.RealWareApiConnectionSettings.Token,
                    _addIn.Settings.RealWareApiConnectionSettings.RealWareUserName);

            isConnectedToRealWare = validator.Validate(showForm);

            return validator;
        }
        #endregion

        #region ImportFromListBuilder
        public void OnImportFromRealWareClick(IRibbonControl control)
        {
            var form = new ListBuilderForm(_addIn.GetRealWareApi(), _addIn.Settings.GeneralSettings);

            if (form.ShowDialog() == DialogResult.OK)
            {
                string selectedSheetName = null;

                if (form.ReplaceCurrentSheet)
                    selectedSheetName = _addIn.ExcelController.GetSelectedSheetName();
                    
                _addIn.ExcelController.CreateNewSheet(
                    form.SelectedListBuilderItem.Name, 
                    form.Result);

                if(selectedSheetName != null)
                    _addIn.ExcelController.DeleteSheet(selectedSheetName);
            }
        }

        public Bitmap GetImportFromListBuilderImage(IRibbonControl control)
            => Resources.ico_realware_listbuilder_128x128;

        public bool GetImportFromListBuilderEnabled(IRibbonControl control)
            => isConnectedToRealWare;

        public bool GetImportFromListBuilderVisible(IRibbonControl control)
            => _addIn.HasModule<List>();
        #endregion

        #region BatchAccounts
        public void OnBatchAccountsClick(IRibbonControl control)
        {
            var currentWorkbook = _addIn.Application.ActiveWorkbook;

            if(currentWorkbook == null)
            {
                MessageBox.Show("No workbook is currently active.\r\n\r\nYou must have a workbook loaded to use the batch feature.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_addIn.ExcelController.GetSheetNames().Count > 1)
            {
                MessageBox.Show("You must have only one sheet in the workbook to use the batch feature.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string destinationPath = _addIn.Settings.BatchWizardSettings.ScriptsDirectory + "\\" + timestamp;

            try
            {
                System.IO.Directory.CreateDirectory(destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create directory for batch wizard scripts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string originalFileName = currentWorkbook.Name;
            var excelFileName = Path.Combine(destinationPath, originalFileName);
            try
            {
                // Ensure the file has the correct extension
                if (!excelFileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) &&
                    !excelFileName.EndsWith(".xlsm", StringComparison.OrdinalIgnoreCase))
                {
                    excelFileName += ".xlsx";
                }

                // Save a copy of the current workbook
                currentWorkbook.SaveCopyAs(excelFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save workbook copy: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load the batch wizard
            var context = new BatchWizardContext(
                _addIn.ExcelController, 
                _addIn.Settings.RealWareApiConnectionSettings, 
                _addIn.Settings.BatchWizardSettings,
                _addIn.Settings.RealWareDbConnectionSettings,
                excelFileName);

            var form = new BatchWizardForm(context);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.RunScript(_addIn.Settings.BatchWizardSettings.RealWareApiAssistantExePath);

                _addIn.SaveSettings();
            }
        }

        public Bitmap GetBatchAccountsImage(IRibbonControl control)
            => Resources.ico_realware_batch_128x128;

        public bool GetBatchAccountsEnabled(IRibbonControl control)
            => isConnectedToRealWare;
        #endregion

        #region ViewBatchScripts
        public void OnViewBatchScriptsClick(IRibbonControl control)
        {
            string destinationPath = _addIn.Settings.BatchWizardSettings.ScriptsDirectory + "\\";

            if (!Directory.Exists(destinationPath))
            {
                MessageBox.Show("No batch wizard scripts have been saved yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open directory for batch wizard scripts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bitmap GetViewBatchScriptsImage(IRibbonControl control)
            => Resources.ico_view_batch_scripts_128x128;

        public bool GetViewBatchScriptsEnabled(IRibbonControl control)
            => true;
        #endregion

        #region Settings
        public void OnSettingsClick(IRibbonControl control)
        {
            var form = new WinCore.Forms.SettingsForm(_addIn.Settings);

            if(form.ShowDialog() == DialogResult.OK)
            {
                _addIn.SaveSettings(form.GetSettings());
            }
        }

        public Bitmap GetSettingsImage(IRibbonControl control)
            => Resources.ico_realware_settings_128x128;
        #endregion
    }
}
