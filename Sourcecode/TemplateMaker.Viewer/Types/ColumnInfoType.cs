using TemplateMaker.Viewer.Helpers.SmartString;
using TemplateMaker.Viewer.Helpers.SmartType;

namespace TemplateMaker.Viewer.Types
{
    internal class ColumnInfoType
    {
        public SmartString Name { get; set; } = string.Empty;
        public SmartType Type { get; set; }
    }
}
