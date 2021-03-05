using TemplateProcessor.Helpers.SmartType.Enums;

namespace TemplateProcessor.Helpers.SmartType
{
    public class SmartType
    {
        private ETypeLanguage OriginalLanguage;
        private string OriginalValue;

        public string Oracle { get => GetOracleType(); }

        public string CSharp { get => GetCSharpType(); }

        public string Pascal { get => GetPascalType(); }

        public SmartType()
        {
        }

        public SmartType(string type, ETypeLanguage language)
        {
            SetValue(type, language);
        }

        private void SetValue(string value, ETypeLanguage language)
        {
            OriginalLanguage = language;
            OriginalValue = value;
        }

        public string GetOracleType()
        {
            return SmartTypeDictionary.GetType(OriginalValue, OriginalLanguage, ETypeLanguage.Oracle);
        }

        public string GetCSharpType()
        {
            return SmartTypeDictionary.GetType(OriginalValue, OriginalLanguage, ETypeLanguage.CSharp);
        }

        public string GetPascalType()
        {
            return SmartTypeDictionary.GetType(OriginalValue, OriginalLanguage, ETypeLanguage.Pascal);
        }

        public override string ToString()
        {
            return CSharp;
        }
    }
}
