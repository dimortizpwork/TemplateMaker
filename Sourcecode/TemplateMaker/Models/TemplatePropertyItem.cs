using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Types;
using TemplateMaker.Views.PropertyEditors;
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
            if (GetIsCollection())
            {
                if (Type == ETemplatePropertyType.String)
                    return typeof(ICollection<string>);
                else if (Type == ETemplatePropertyType.TableInfo)
                    return typeof(ICollection<TableInfoType>);
            }
            else
            {
                if (Type == ETemplatePropertyType.String)
                    return typeof(string);
                else if (Type == ETemplatePropertyType.TableInfo)
                    return typeof(TableInfoType);
            }
            return null;
        }

        public string GetDisplayValue()
        {
            if (GetValue() != null)
            {
                if (GetIsCollection())
                { 
                    if (Type == ETemplatePropertyType.String)
                        return $"[Collection::String][{(GetValue() as ICollection<object>).Count()}]";
                    else if (Type == ETemplatePropertyType.TableInfo)
                        return $"[Collection::TableInfo][{(GetValue() as ICollection<object>).Count()}]";
                }
                else
                {
                    if (Type == ETemplatePropertyType.String)
                        return GetValue() as string;
                    else if (Type == ETemplatePropertyType.TableInfo)
                        return $"[Object::TableInfo] {(GetValue() as TableInfoType).FullName}";
                }
            }
            return null;
        }

        public Type GetEditorType()
        {
            if (Type == ETemplatePropertyType.TableInfo)
                return typeof(TableInfoPropertyEditor);
            return null;
        }

        public bool GetIsCollection()
        {
            return IsCollection;
        }
    }
}
