namespace TemplateProcessor.Models
{
    public enum ETemplatePropertyType
    {
        String,
        TableInfo,
        ApiInfo
    }

    public class TemplateProperty
    {
        public string Name { get; set; }
        public ETemplatePropertyType Type { get; set; } = ETemplatePropertyType.String;
        public bool Required { get; set; } = true;
        public object DefaultValue { get; set; }
        public bool IsCollection { get; set; } = false;
    }
}
