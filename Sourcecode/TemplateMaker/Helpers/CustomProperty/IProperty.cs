using System;
using System.ComponentModel;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{
    public interface IProperty
    {
        string GetName();
        string GetDescription();
        string GetDisplayValue();
        object GetValue();
        void SetValue(object value);
        Type GetValueType();
        Type GetEditorType();
    }
}
