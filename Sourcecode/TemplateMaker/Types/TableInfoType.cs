using System.Collections.Generic;

namespace TemplateMaker.Viewer.Types
{
    public class TableInfoType
    {
        public string Name { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public IEnumerable<ColumnInfoType> Columns { get; set; }
    }
}
