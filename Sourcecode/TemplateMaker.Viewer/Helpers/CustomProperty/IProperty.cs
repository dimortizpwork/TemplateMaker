using System;
using System.ComponentModel;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{
    internal interface IProperty
    {
        string GetName();
        string GetDescription();
        object GetValue();
        void SetValue(object value);
        Type GetValueType();
    }
}
