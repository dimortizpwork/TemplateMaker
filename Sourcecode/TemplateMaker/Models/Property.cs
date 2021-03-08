using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMaker.Viewer.Types;
using TemplateMaker.Views.PropertyEditors;
using TemplateProcessor;
using TemplateProcessor.Models;

namespace TemplateMaker.Viewer.Models
{
    public class Property : IProperty
    {
        private TemplateParameter TemplateParameter;

        public Property(TemplateParameter templateParameter)
        {
            TemplateParameter = templateParameter;

            //When loading, the Value is an JArray object, so this code will tranform it in a propert IEnumrable<TemplateParameter>
            if (TemplateParameter.IsParameterObject)
                TemplateParameter.Value = JArrayToTemplateParameterCollection(TemplateParameter);
        }

        private IEnumerable<TemplateParameter> JArrayToTemplateParameterCollection(TemplateParameter parameter)
        {
            if(parameter.Value.GetType().IsAssignableFrom(typeof(JArray)))
                return JsonConvert.DeserializeObject<IEnumerable<TemplateParameter>>(parameter.Value.ToString());
            return parameter.Value as IEnumerable<TemplateParameter>;
        }

        public string GetDescription()
        {
            return TemplateParameter.Name;
        }

        public string GetName()
        {
            return TemplateParameter.Name;
        }

        public object GetValue()
        {
            if (GetIsParameterObject())
            {
                List<IProperty> proprs = new List<IProperty>();
                foreach (TemplateParameter templateParameter in TemplateParameter.Value as IEnumerable<TemplateParameter>)
                    proprs.Add(new Property(templateParameter));
                return proprs;
            }
            else
                return TemplateParameter.Value;
        }

        public void SetValue(object value)
        {
            if (!GetIsParameterObject())
                TemplateParameter.Value = value;
        }

        public Type GetValueType()
        {
            if (GetIsCollection())
            {
                if (TemplateParameter.Type == ETemplateParameterType.String)
                    return typeof(ICollection<string>);
                else if (TemplateParameter.Type == ETemplateParameterType.Object)
                    return typeof(ICollection<TemplateParameter>);
                else if (TemplateParameter.Type == ETemplateParameterType.TableInfo)
                    return typeof(ICollection<TableInfoType>);
                else if (TemplateParameter.Type == ETemplateParameterType.ApiInfo)
                    return typeof(ICollection<ApiInfoType>);
            }
            else
            {
                if (TemplateParameter.Type == ETemplateParameterType.String)
                    return typeof(string);
                else if (TemplateParameter.Type == ETemplateParameterType.Object)
                    return typeof(TemplateParameter);
                else if (TemplateParameter.Type == ETemplateParameterType.TableInfo)
                    return typeof(TableInfoType);
                else if (TemplateParameter.Type == ETemplateParameterType.ApiInfo)
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
                    if (TemplateParameter.Type == ETemplateParameterType.String)
                        return $"[Collection::String][{(GetValue() as ICollection<object>).Count()}]";
                    else if (TemplateParameter.Type == ETemplateParameterType.Object)
                        return $"[Collection::Object][{(GetValue() as ICollection<object>).Count()}]";
                    else if (TemplateParameter.Type == ETemplateParameterType.TableInfo)
                        return $"[Collection::TableInfo][{(GetValue() as ICollection<object>).Count()}]";
                    else if (TemplateParameter.Type == ETemplateParameterType.ApiInfo)
                        return $"[Collection::ApiInfo][{(GetValue() as ICollection<object>).Count()}]";
                }
                else
                {
                    if (TemplateParameter.Type == ETemplateParameterType.String)
                        return GetValue() as string;
                    else if (TemplateParameter.Type == ETemplateParameterType.Object)
                        return $"[Object::Object]";
                    else if (TemplateParameter.Type == ETemplateParameterType.TableInfo)
                        return $"[Object::TableInfo] {(GetValue() as TableInfoType).FullName}";
                    else if (TemplateParameter.Type == ETemplateParameterType.ApiInfo)
                        return $"[Object::ApiInfo] {(GetValue() as ApiInfoType).Name}";
                }
            }
            return null;
        }

        public Type GetCustomEditorType()
        {
            if (TemplateParameter.Type == ETemplateParameterType.TableInfo)
                return typeof(TableInfoPropertyEditor);
            else if (TemplateParameter.Type == ETemplateParameterType.ApiInfo)
                return typeof(ApiInfoPropertyEditor);
            return null;
        }

        public bool GetIsCollection()
        {
            return TemplateParameter.IsCollection;
        }

        public bool GetIsParameterObject()
        {
            return TemplateParameter.IsParameterObject;
        }
    }
}
