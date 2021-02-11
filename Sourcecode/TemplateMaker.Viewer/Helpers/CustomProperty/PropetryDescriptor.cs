using System;
using System.ComponentModel;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{
    internal class PropertyDescriptor<T> : PropertyDescriptor where T : IProperty
    {
        private T Property;

        public PropertyDescriptor(T property) : base(property.GetName(), null)
        {
            Property = property;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return Property.GetValueType();
            }
        }

        public override string DisplayName
        {
            get
            {
                return Property.GetName();
            }
        }

        public override string Description
        {
            get
            {
                return Property.GetDescription();
            }
        }

        public override object GetValue(object component)
        {
            return Property.GetValue();
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override string Name
        {
            get { return Property.GetName(); }
        }

        public override Type PropertyType
        {
            get { return Property.GetValueType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            Property.SetValue(value);
        }
    }
}
