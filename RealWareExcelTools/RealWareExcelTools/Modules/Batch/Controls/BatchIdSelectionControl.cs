using RealWareExcelTools.Modules.Batch.Models;
using System;

namespace RealWareExcelTools.Modules.Batch.Controls
{
    public partial class BatchIdSelectionControl : DevExpress.XtraEditors.XtraUserControl
    {
        IdValueType valueType;

        public event EventHandler<IdValueType> OnSetValueEvent;

        public BatchIdSelectionControl()
        {
            InitializeComponent();

            chkUseExcelValue.CheckedChanged += (s,e) => refreshComboBoxDropdownVisibility();
        }

        public void SetIdColumn(IdValueType valueType)
        {
            this.valueType = valueType;

            layoutControlItemHeader.Text = valueType.ToString() + ":";

            refreshComboBoxDropdownVisibility();

            OnSetValueEvent?.Invoke(this, this.valueType);
        }

        public bool IsValid()
        {
            if (valueType == IdValueType.None)
                return true;

            return !string.IsNullOrEmpty(cmbIdValue.Text);
        }

        private void refreshComboBoxDropdownVisibility()
        {
            cmbIdValue.Properties.TextEditStyle = chkUseExcelValue.Checked
                ? DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                : DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            cmbIdValue.Properties.Buttons[0].Visible = chkUseExcelValue.Checked;
        }
    }
}
