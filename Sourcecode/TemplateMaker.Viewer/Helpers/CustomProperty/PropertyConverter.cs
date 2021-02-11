using System;
using System.ComponentModel;
using System.Globalization;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{
    internal class PropertyConverter<T> : ExpandableObjectConverter where T: IConvertable
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is T)
            {
                return (value as IConvertable).ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
