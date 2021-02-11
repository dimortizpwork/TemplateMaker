using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Models.Types;

namespace TemplateMaker.Viewer.Helpers.PropertyEditors
{
    internal partial class FormTableInfoPropertyEditor : Form, IPropertyEditorForm
    {
        public TableInfo Value { get; set; }
        public FormTableInfoPropertyEditor()
        {
            InitializeComponent();
        }

        public void SetValue(object value)
        {
            Value = value as TableInfo;
        }

        public object GetValue()
        {
            return Value;
        }

        private void LoadValue()
        {
            if (Value == null)
                Value = new TableInfo();
            textBoxFullName.Text = Value.FullName.Default;
        }
        private void FormTableInfoPropertyEditor_Shown(object sender, EventArgs e)
        {
            LoadValue();
        }
    }
}
