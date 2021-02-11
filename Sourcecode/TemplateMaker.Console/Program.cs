namespace TemplateMaker.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Settings settings = GetSettings(args);      
        }

        private static Settings GetSettings(string[] args)
        {
            return new Settings()
            {
                TemplateData = GetArg(args, "TemplateData"),
                OutputPath = GetArg(args, "OutputPath"),
                TemplatePath = GetArg(args, "TemplatePath")
            };
        }

        private static string GetArg(string[] args, string argName)
        {
            for (var i = 0; i < args.Length; i++) {
                var arg = args[i];
                if (arg.ToLower() == $"--{argName}".ToLower())
                {
                    return args[i + 1];
                }
            }
            return null;
        }
    }
}
