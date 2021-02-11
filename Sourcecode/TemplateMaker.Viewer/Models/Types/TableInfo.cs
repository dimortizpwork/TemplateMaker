using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Helpers.PropertyEditors;
using TemplateMaker.Viewer.Helpers.SmartString;

namespace TemplateMaker.Viewer.Models.Types
{

    [Editor(typeof(PropertyEditor<FormTableInfoPropertyEditor>), typeof(UITypeEditor))]
    internal class TableInfo
    {
        public SmartString Name { get; set; } = new SmartString();
        public SmartString Prefix { get; set; } = new SmartString();
        public SmartString FullName { get; set; } = new SmartString();
        public IEnumerable<ColumnInfo> Columns { get; set; }
    }

    internal class ColumnInfo
    {
        public SmartString Name { get; set; } = new SmartString();
    }
}
