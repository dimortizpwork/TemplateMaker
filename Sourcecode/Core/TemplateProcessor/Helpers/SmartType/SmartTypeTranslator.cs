using TemplateProcessor.Helpers.SmartType.Enums;

namespace TemplateProcessor.Helpers.SmartType
{
    public class SmartTypeTranslator
    {
        public ETypeLanguage Language { get; set; }
        public ETypeUnit Unit { get; set; }
        public string SearchPattern { get; set; }
        public string Value { get; set; }

        public SmartTypeTranslator(ETypeLanguage language, ETypeUnit unit, string searchPattern, string value)
        {
            Language = language;
            Unit = unit;
            SearchPattern = searchPattern;
            Value = value;
        }
    }
}
