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
        public SmartString Name { get; set; }
        public SmartString Prefix { get; set; }
        public SmartString FullName { get; set; }
        public IEnumerable<ColumnInfo> Columns { get; set; }
    }

    internal class ColumnInfo
    {
        public SmartString Name { get; set; }
    }
}
