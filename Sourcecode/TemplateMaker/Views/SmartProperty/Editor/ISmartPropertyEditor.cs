using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMaker.Viewer.Views.SmartProperty.Editor
{
    public interface ISmartPropertyEditor
    {
        void SetValue(object value);
        object GetValue();
    }
}
