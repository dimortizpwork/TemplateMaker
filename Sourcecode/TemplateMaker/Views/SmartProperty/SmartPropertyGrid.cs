using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Views.SmartProperty.Editor;

namespace TemplateMaker.Viewer.Views.SmartProperty
{
    public delegate void SmartPropertyGridOnPropertyValueChangeHandler(IProperty property);
    public partial class SmartPropertyGrid : UserControl
    {
        private IList<IProperty> Properties;
        public event SmartPropertyGridOnPropertyValueChangeHandler PropertyValueChanged;

        public SmartPropertyGrid()
        {
            InitializeComponent();
        }

        public void LoadProperties(IList<IProperty> properties)
        {
            Properties = properties;
            dataGridView.Rows.Clear();
            foreach (IProperty property in Properties) {
                int index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells["ColumnPropertyName"].Value = property.GetName();
                dataGridView.Rows[index].Cells["ColumnPropertyValue"].Value = property.GetDisplayValue();
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IProperty property = Properties[e.RowIndex];
            if (property.GetValueType() == typeof(string))
                property.SetValue(dataGridView.Rows[e.RowIndex].Cells["ColumnPropertyValue"].Value);
            PropertyValueChanged?.Invoke(property);
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IProperty property = Properties[e.RowIndex];
            Type smartPropertyEditor = property.GetEditorType();
            if (smartPropertyEditor != null)
            {
                e.Cancel = true;
                object value = dataGridView.Rows[e.RowIndex].Cells["ColumnPropertyValue"].Value;
                FormSmartPropertyEditor formPropertyEditor = new FormSmartPropertyEditor();
                formPropertyEditor.DefinePropertyEditor(smartPropertyEditor);
                formPropertyEditor.SetValue(value);
                if (formPropertyEditor.ShowDialog() == DialogResult.OK)
                {
                    value = formPropertyEditor.GetValue();
                    dataGridView.Rows[e.RowIndex].Cells["ColumnPropertyValue"].Value = value;
                    property.SetValue(value);
                    PropertyValueChanged?.Invoke(property);
                }
            }
        }
    }
}
