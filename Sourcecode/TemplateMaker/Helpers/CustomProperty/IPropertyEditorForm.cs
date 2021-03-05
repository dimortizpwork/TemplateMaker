using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{
    interface IPropertyEditorForm
    {
        void SetValue(object value);
        object GetValue();
    }
}
