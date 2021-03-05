using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateMaker.Viewer.Views.SmartProperty.Editor
{
    public partial class FormSmartPropertyEditor : Form
    {
        private UserControl Editor;
        public FormSmartPropertyEditor()
        {
            InitializeComponent();
        }

        public void DefinePropertyEditor(Type editorType)
        {
            if (editorType.IsSubclassOf(typeof(UserControl)))
            {
                Editor = (UserControl)Activator.CreateInstance(editorType);
                this.ClientSize = new Size(Editor.Width, Editor.Height + panelBottom.Height);
                Editor.Parent = this.panelRenderEditor;
                Editor.Dock = DockStyle.Fill;
            }
        }

        public void SetValue(object value)
        {
            (Editor as ISmartPropertyEditor).SetValue(value);
        }

        public object GetValue()
        {
            return (Editor as ISmartPropertyEditor).GetValue();
        }

    }
}
