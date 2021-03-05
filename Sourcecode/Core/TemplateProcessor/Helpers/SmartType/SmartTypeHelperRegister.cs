using HandlebarsDotNet;
using TemplateProcessor.Helpers.SmartType.Enums;

namespace TemplateProcessor.Helpers.SmartType
{
    public static class SmartTypeHelperRegister
    {
        public static void Register()
        {
            Handlebars.RegisterHelper("OracleToPascal", (output, context, arguments) => output.Write(new SmartType((string)arguments[0], ETypeLanguage.Oracle).Pascal));
            Handlebars.RegisterHelper("OracleToCSharp", (output, context, arguments) => output.Write(new SmartType((string)arguments[0], ETypeLanguage.Oracle).CSharp));

            Handlebars.RegisterHelper("PascalToOracle", (output, context, arguments) => output.Write(new SmartType((string)arguments[0], ETypeLanguage.Pascal).Oracle));
            Handlebars.RegisterHelper("PascalToCSharp", (output, context, arguments) => output.Write(new SmartType((string)arguments[0], ETypeLanguage.Pascal).CSharp));

            Handlebars.RegisterHelper("CSharpToPascal", (output, context, arguments) => output.Write(new SmartType((string)arguments[0], ETypeLanguage.CSharp).Pascal));
            Handlebars.RegisterHelper("CSharpToOracle", (output, context, arguments) => output.Write(new SmartType((string)arguments[0], ETypeLanguage.CSharp).Oracle));
        }
    }
}