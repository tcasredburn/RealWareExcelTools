using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Forms
{
    public static class ErrorMessage
    {
        public static void ShowErrorMessage(ErrorMessageType errorType, string errorDetails)
        {
            string header = "Error";
            string message = "Details:\r\n";
            switch(errorType)
            {
                case ErrorMessageType.Settings_FailedToSave:
                    header = "Failed to Save Settings";
                    message += errorDetails;
                    break;
                case ErrorMessageType.ListBuilder_FailedToLoadQueries:
                    header = "Failed to Load Listbuilder Queries";
                    message += errorDetails; 
                    break;
                default:
                    throw new NotImplementedException("Error type not implemented.");
            }

            ShowErrorMessage(message, header);
        }

        public static void ShowErrorMessage(string text, string caption)
        {
            XtraMessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public enum ErrorMessageType
    {
        Settings_FailedToSave,
        ListBuilder_FailedToLoadQueries
    }
}
