namespace TemplateProcessor.Helpers.SmartString
{
    public class SmartString
    {
        private string Value;
        public string Default { get => Value; set => SetValue(value); }
        public string CamelCase { get => GetCamelCase(); }
        public string SnakeCase { get => GetSnakeCase(); }
        public string PascalCase { get => GetPascalCase(); }
        public string LowerCase { get => GetLowerCase(); }
        public string UpperCase { get => GetUpperCase(); }

        public SmartString()
        {
        }

        public SmartString(string value)
        {
            Default = value;
        }

        public static implicit operator SmartString(string value)
        {
            return new SmartString(value);
        }

        private void SetValue(string value)
        {
            Value = value;
        }

        private string GetCamelCase()
        {
            return SmartStringDictionary.GetCamelCase(Value);
        }

        private string GetSnakeCase()
        {
            return SmartStringDictionary.GetSnakeCase(Value);
        }
        private string GetPascalCase()
        {
            return SmartStringDictionary.GetPascalCase(Value);
        }

        private string GetUpperCase()
        {
            return Value.ToUpper();
        }

        private string GetLowerCase()
        {
            return Value.ToLower();
        }

        public override string ToString()
        {
            return Default;
        }
    }
}
