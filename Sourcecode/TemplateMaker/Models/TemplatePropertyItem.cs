using System;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Types;
using TemplateProcessor.Models;

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
                    return typeof(TableInfoType);
                default:
                    return null;
            }
        }

        public string GetDisplayValue()
        {
            switch (Type)
            {
                case ETemplatePropertyType.String:
                    return GetValue() as string;
                case ETemplatePropertyType.TableInfo:
                    return GetValue() != null ? (GetValue() as TableInfoType).Name : null;
                default:
                    return null;
            }
        }
    }
}
