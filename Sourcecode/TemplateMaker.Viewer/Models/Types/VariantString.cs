
using System.ComponentModel;
using TemplateMaker.Viewer.Helpers.CustomProperty;

namespace TemplateMaker.Viewer.Models.Types
{
    internal class VariantString
    {
        private string Value;
        public string Original { get => Value; set => SetValue(value); }
        public string CamelCase { get; set; }
        public string SnakeCase { get; set; }
        public string PascalCase { get; set; }
        public string LowerCase { get; set; }
        public string UpperCase { get; set; }

        public VariantString()
        {
        }

        public VariantString(string value)
        {
            Original = value;
        }

        private void SetValue(string value)
        {
            Value = value;
            CamelCase = value;
            SnakeCase = value;
            PascalCase = value;
            LowerCase = value.ToLower();
            UpperCase = value.ToUpper();
        }
    }
}
