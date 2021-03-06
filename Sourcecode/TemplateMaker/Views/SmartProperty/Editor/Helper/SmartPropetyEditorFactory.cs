using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateMaker.Viewer.Helpers.CustomProperty;

namespace TemplateMaker.Viewer.Views.SmartProperty.Editor.Helper
{
    public delegate void SmartPropetyEditorFactoryOnEndEditHanlder(IProperty property, object value);
    public class SmartPropetyEditorFactory
    {
        public static object OpenEditor(Type editorType, object value, bool isCollection)
        {
            IFromSmartPropertyEditor formEditor;
            if (isCollection)
                formEditor = new FormSmartPropertyCollectionEditor();
            else
                formEditor = new FormSmartPropertyEditor();

            formEditor.DefinePropertyEditor(editorType);
            formEditor.SetValue(value);
            if ((formEditor as Form).ShowDialog() == DialogResult.OK)
                value = formEditor.GetValue();
            return value;
        }
    }
}
