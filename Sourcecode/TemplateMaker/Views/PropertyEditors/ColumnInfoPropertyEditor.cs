using System.Windows.Forms;
using SmartProperty.Editors;
using TemplateMaker.Viewer.Types;

namespace TemplateMaker.Viewer.Views.PropertyEditors
{
    public partial class ColumnInfoPropertyEditor : UserControl, ISmartPropertyEditor
    {
        public ColumnInfoType Value { get; set; }
        public ColumnInfoPropertyEditor()
        {
            InitializeComponent();
        }

        public void SetValue(object value)
        {
            Value = value as ColumnInfoType;
            LoadValue();
        }

        public object GetValue()
        {
            Value.Name = textBoxName.Text;
            Value.Type = textBoxType.Text;
            return Value;
        }

        private void LoadValue()
        {
            if (Value == null)
                Value = new ColumnInfoType();
            textBoxName.Text = Value.Name;
            textBoxType.Text = Value.Type;
        }
    }
}
