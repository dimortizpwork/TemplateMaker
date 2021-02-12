
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TemplateMaker.Viewer.Helpers.CustomProperty;

namespace TemplateMaker.Viewer.Helpers.SmartString
{
    internal class SmartString
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
            return SmartStringDictonary.GetCamelCase(Value);
        }

        private string GetSnakeCase()
        {
            return SmartStringDictonary.GetSnakeCase(Value);
        }
        private string GetPascalCase()
        {
            return SmartStringDictonary.GetPascalCase(Value);
        }

        private string GetUpperCase()
        {
            return Value.ToUpper();
        }

        private string GetLowerCase()
        {
            return Value.ToLower();
        }
    }
}
