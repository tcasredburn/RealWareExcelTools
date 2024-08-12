using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace RealWareExcelTools.WinCore.Forms
{
    public static class ErrorMessage
    {
        public static void ShowErrorMessage(string text, string caption)
        {
            XtraMessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
