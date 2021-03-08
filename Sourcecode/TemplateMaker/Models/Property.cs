using SmartProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMaker.Viewer.Types;
using TemplateMaker.Views.PropertyEditors;
using TemplateProcessor.Models;

namespace TemplateMaker.Viewer.Models
{
    public class Property : IProperty
    {
        private TemplateParameter TemplateProperty;

        public Property(TemplateParameter templateProperty)
        {
            TemplateProperty = templateProperty;
        }

        public string GetDescription()
        {
            return TemplateProperty.Name;
        }

        public string GetName()
        {
            return TemplateProperty.Name;
        }

        public object GetValue()
        {
            return TemplateProperty.Value;
        }

        public void SetValue(object value)
        {
            TemplateProperty.Value = value;
        }

        public Type GetValueType()
        {
            if (GetIsCollection())
            {
                if (TemplateProperty.Type == ETemplateParameterType.String)
                    return typeof(ICollection<string>);
                else if (TemplateProperty.Type == ETemplateParameterType.Object)
                    return typeof(ICollection<object>);
                else if (TemplateProperty.Type == ETemplateParameterType.TableInfo)
                    return typeof(ICollection<TableInfoType>);
                else if (TemplateProperty.Type == ETemplateParameterType.ApiInfo)
                    return typeof(ICollection<ApiInfoType>);
            }
            else
            {
                if (TemplateProperty.Type == ETemplateParameterType.String)
                    return typeof(string);
                else if (TemplateProperty.Type == ETemplateParameterType.Object)
                    return typeof(object);
                else if (TemplateProperty.Type == ETemplateParameterType.TableInfo)
                    return typeof(TableInfoType);
                else if (TemplateProperty.Type == ETemplateParameterType.ApiInfo)
                    return typeof(ApiInfoType);
            }
            return null;
        }

        public string GetDisplayValue()
        {
            if (GetValue() != null)
            {
                if (GetIsCollection())
                { 
                    if (TemplateProperty.Type == ETemplateParameterType.String)
                        return $"[Collection::String][{(GetValue() as ICollection<object>).Count()}]";
                    else if (TemplateProperty.Type == ETemplateParameterType.Object)
                        return $"[Collection::Object][{(GetValue() as ICollection<object>).Count()}]";
                    else if (TemplateProperty.Type == ETemplateParameterType.TableInfo)
                        return $"[Collection::TableInfo][{(GetValue() as ICollection<object>).Count()}]";
                    else if (TemplateProperty.Type == ETemplateParameterType.ApiInfo)
                        return $"[Collection::ApiInfo][{(GetValue() as ICollection<object>).Count()}]";
                }
                else
                {
                    if (TemplateProperty.Type == ETemplateParameterType.String)
                        return GetValue() as string;
                    else if (TemplateProperty.Type == ETemplateParameterType.Object)
                        return $"[Object::Object]";
                    else if (TemplateProperty.Type == ETemplateParameterType.TableInfo)
                        return $"[Object::TableInfo] {(GetValue() as TableInfoType).FullName}";
                    else if (TemplateProperty.Type == ETemplateParameterType.ApiInfo)
                        return $"[Object::ApiInfo] {(GetValue() as ApiInfoType).Name}";
                }
            }
            return null;
        }

        public Type GetEditorType()
        {
            if (TemplateProperty.Type == ETemplateParameterType.Object)
                return typeof(ObjectPropertyEditor);
            else if (TemplateProperty.Type == ETemplateParameterType.TableInfo)
                return typeof(TableInfoPropertyEditor);
            else if (TemplateProperty.Type == ETemplateParameterType.ApiInfo)
                return typeof(ApiInfoPropertyEditor);
            return null;
        }

        public bool GetIsCollection()
        {
            return TemplateProperty.IsCollection;
        }
    }
}
