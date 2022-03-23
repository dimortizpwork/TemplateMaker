using System.Windows.Forms;
using SmartProperty.Editors;
using TemplateMaker.Viewer.Types;

namespace TemplateMaker.Viewer.Views.PropertyEditors
{
    public partial class ApiInfoPropertyEditor : UserControl, ISmartPropertyEditor
    {
        public ApiInfoType Value { get; set; }
        public ApiInfoPropertyEditor()
        {
            InitializeComponent();
        }

        public void SetValue(object value)
        {
            Value = value as ApiInfoType;
            LoadValue();
        }

        public object GetValue()
        {
            Value.Name = textBoxName.Text;
            return Value;
        }

        private void LoadValue()
        {
            if (Value == null)
                Value = new ApiInfoType();
            textBoxName.Text = Value.Name;
        }
    }
}
