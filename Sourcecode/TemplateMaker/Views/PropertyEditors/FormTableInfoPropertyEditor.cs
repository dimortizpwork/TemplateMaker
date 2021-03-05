using SchemaProcessor;
using SchemaProcessor.SchemaProviders;
using SchemaProcessor.Schemas;
using System;
using System.Windows.Forms;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Types;

namespace TemplateMaker.Viewer.Helpers.PropertyEditors
{
    internal partial class FormTableInfoPropertyEditor : Form, IPropertyEditorForm
    {
        private readonly SchemaProviderManager SchemaProviderManager;
        public TableInfoType Value { get; set; }
        public FormTableInfoPropertyEditor()
        {
            InitializeComponent();
            SchemaProviderManager = new SchemaProviderManager();
        }

        public void SetValue(object value)
        {
            Value = value as TableInfoType;
        }

        public object GetValue()
        {
            return Value;
        }

        private void LoadValue()
        {
            foreach (ISchemaProvider schemaProvider in SchemaProviderManager.GetProviders())
                comboBoxProvider.Items.Add(schemaProvider);
            if (comboBoxProvider.Items.Count > 0)
                comboBoxProvider.SelectedIndex = 0;

            if (Value == null)
                Value = new TableInfoType();
            textBoxFullName.Text = Value.FullName;
            textBoxName.Text = Value.Name;
            textBoxPrefix.Text = Value.Prefix;


            var souce = new BindingSource();
            souce.DataSource = Value.Columns;
            dataGridViewColumns.AutoGenerateColumns = false;
            dataGridViewColumns.DataSource = souce;
            
        }

        private ISchemaProvider GetSelectedSchemaProvider()
        {
            return comboBoxProvider.SelectedItem as ISchemaProvider;
        }

        private void FormTableInfoPropertyEditor_Shown(object sender, EventArgs e)
        {
            LoadValue();
        }

        private void buttonLoadTableInfo_Click(object sender, EventArgs e)
        {
            Value = SchemaProvider.SchemaProvider.GetTableInfo(GetSelectedSchemaProvider(), textBoxEntityName.Text);
            LoadValue();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
