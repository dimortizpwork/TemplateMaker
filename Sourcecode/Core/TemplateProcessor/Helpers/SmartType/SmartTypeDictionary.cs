using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TemplateProcessor.Helpers.SmartType.Enums;

namespace TemplateProcessor.Helpers.SmartType
{
    public class SmartTypeDictionary
    {
        private static List<SmartTypeTranslator> Translators = new List<SmartTypeTranslator>();
        public static void LoadTypes()
        {
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.CSharp, ETypeUnit.Char, @"char", "char"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.CSharp, ETypeUnit.String, @"string", "string"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.CSharp, ETypeUnit.Integer, @"int", "int"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.CSharp, ETypeUnit.Float, @"float", "float"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.CSharp, ETypeUnit.Boolean, @"bool", "bool"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.CSharp, ETypeUnit.DateTime, @"DateTime", "DateTime"));

            Translators.Add(new SmartTypeTranslator(ETypeLanguage.Oracle, ETypeUnit.Char, @"CHAR", "Char"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.Oracle, ETypeUnit.String, @"VARCHAR2\({0,1}[0-9]{0,}\){0,1}", "VARCHAR(200)"));
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.Oracle, ETypeUnit.Integer, @"NUMBER", "Integer"));
            //Translators.Add(new SmartTypeTranslator(ETypeLanguage.Oracle, ETypeUnit.Float, @"float", "float")); 
            //Translators.Add(new SmartTypeTranslator(ETypeLanguage.Oracle, ETypeUnit.Boolean, @"bool", "bool")); 
            Translators.Add(new SmartTypeTranslator(ETypeLanguage.Oracle, ETypeUnit.DateTime, @"DATE", "DateTime"));
        }

        public static string GetType(string value, ETypeLanguage originalLanguage, ETypeLanguage outputLanguage)
        {
            var unit = ETypeUnit.Undefined;
            //Find the unit int the Original Language
            foreach (SmartTypeTranslator translator in Translators.Where(x => x.Language == originalLanguage))
            {
                if (Regex.IsMatch(value, translator.SearchPattern, RegexOptions.IgnoreCase))
                    unit = translator.Unit;
            }

            //Find the translation value in the other languages
            var type = Translators.Where(x => x.Language == outputLanguage && x.Unit == unit).FirstOrDefault();
            if (type != null)
                return type.Value;
            return null;
        }
    }
}
