using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Helpers.PropertyEditors;
using TemplateProcessor.Helpers.SmartString;

namespace TemplateMaker.Viewer.Types
{
    internal class TableInfoType
    {
        public string Name { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public IEnumerable<ColumnInfoType> Columns { get; set; }
    }
}
