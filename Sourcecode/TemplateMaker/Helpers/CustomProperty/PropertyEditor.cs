using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{
    /*internal class PropertyEditor<T> : UITypeEditor where T: Form, IPropertyEditorForm, new()
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (svc != null)
            {
                using (T form = new T())
                {
                    form.SetValue(value);
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        value = form.GetValue();
                    }
                }
            }
            return value;
        }
    }*/
}
