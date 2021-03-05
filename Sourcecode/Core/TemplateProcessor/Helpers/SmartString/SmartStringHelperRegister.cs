using HandlebarsDotNet;

namespace TemplateProcessor.Helpers.SmartString
{
    public static class SmartStringHelperRegister
    {
        public static void Register()
        {
            Handlebars.RegisterHelper("PascalCase", (output, context, arguments) => output.Write(new SmartString((string)arguments[0]).PascalCase));
            Handlebars.RegisterHelper("CamelCase", (output, context, arguments) => output.Write(new SmartString((string)arguments[0]).CamelCase));
            Handlebars.RegisterHelper("SnakeCase", (output, context, arguments) => output.Write(new SmartString((string)arguments[0]).SnakeCase));
            Handlebars.RegisterHelper("LowerCase", (output, context, arguments) => output.Write(new SmartString((string)arguments[0]).LowerCase));
            Handlebars.RegisterHelper("UpperCase", (output, context, arguments) => output.Write(new SmartString((string)arguments[0]).UpperCase));
        }
    }
}
