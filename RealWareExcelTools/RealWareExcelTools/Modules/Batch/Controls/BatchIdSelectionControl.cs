using RealWareExcelTools.Modules.Batch.Models;
using System;
using System.Collections.Generic;

namespace RealWareExcelTools.Modules.Batch.Controls
{
    public partial class BatchIdSelectionControl : DevExpress.XtraEditors.XtraUserControl
    {
        IdValueType valueType;

        public IdValueType ValueType => valueType;
        public string SelectedValue => cmbIdValue.Text ?? string.Empty;
        public bool UseExcelValue => chkUseExcelValue.Checked;

        public event EventHandler<IdValueType> OnSetValueEvent;
        public event EventHandler<bool> OnWorksheetChangedEvent;

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

        public void SetComboboxValues(List<string> values)
        {
            cmbIdValue.Properties.Items.Clear();
            cmbIdValue.Properties.Items.AddRange(values);
        }

        private void refreshComboBoxDropdownVisibility()
        {
            cmbIdValue.Properties.TextEditStyle = chkUseExcelValue.Checked
                ? DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                : DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            cmbIdValue.Properties.Buttons[0].Visible = chkUseExcelValue.Checked;

            OnWorksheetChangedEvent?.Invoke(this, chkUseExcelValue.Checked);
        }
    }
}
