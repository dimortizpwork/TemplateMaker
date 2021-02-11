using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMaker.Viewer.Helpers.CustomProperty;

namespace TemplateMaker.Viewer.Models.Types
{ 
    internal class TableInfo
    {
        public VariantString Name { get; set; } = new VariantString();
        public VariantString Prefix { get; set; } = new VariantString();
        public VariantString FullName { get; set; } = new VariantString();
        public IEnumerable<ColumnInfo> Columns { get; set; }
    }

    internal class ColumnInfo
    {
        public VariantString Name { get; set; } = new VariantString();
    }
}
