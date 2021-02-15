using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Helpers.PropertyEditors;
using TemplateMaker.Viewer.Helpers.SmartString;

namespace TemplateMaker.Viewer.Types
{

    [Editor(typeof(PropertyEditor<FormTableInfoPropertyEditor>), typeof(UITypeEditor))]
    internal class TableInfoType
    {
        public SmartString Name { get; set; } = string.Empty;
        public SmartString Prefix { get; set; } = string.Empty;
        public SmartString FullName { get; set; } = string.Empty;
        public IEnumerable<ColumnInfoType> Columns { get; set; }
    }
}
