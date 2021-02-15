namespace TemplateProcessor.Models
{
    public enum ETemplatePropertyType
    {
        String,
        TableInfo
    }

    public class TemplateProperty
    {
        public string Name { get; set; }
        public ETemplatePropertyType Type { get; set; } = ETemplatePropertyType.String;
        public bool Required { get; set; } = true;
        public object DefaultValue { get; set; }
    }
}
