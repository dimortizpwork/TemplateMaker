using System;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Models.Types;
using TemplateMaker.Service.Models;

namespace TemplateMaker.Viewer.Models
{
    internal class TemplatePropertyItem : TemplateProperty, IProperty
    {
        private object Value;

        public string GetDescription()
        {
            return Name;
        }

        public string GetName()
        {
            return Name;
        }

        public object GetValue()
        {
            return Value != null ? Value : DefaultValue;
        }

        public void SetValue(object value)
        {
            Value = value;
        }

        public Type GetValueType()
        {
            switch (Type)
            {
                case ETemplatePropertyType.String:
                    return typeof(string);
                case ETemplatePropertyType.TableInfo:
                    return typeof(TableInfo);
                default:
                    return typeof(string);
            }
        }
    }
}
