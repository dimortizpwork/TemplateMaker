using System;

namespace SmartProperty
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
        bool GetIsCollection();
    }
}
