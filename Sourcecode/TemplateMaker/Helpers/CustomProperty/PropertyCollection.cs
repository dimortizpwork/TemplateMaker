using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace TemplateMaker.Viewer.Helpers.CustomProperty
{

    internal class PropertyCollection<T> : CollectionBase, ICustomTypeDescriptor where T: IProperty
    {
        public void Add(T obj)
        {
            List.Add(obj);
        }

        public void Remove(T obj)
        {
            List.Remove(obj);
        }

        public T this[int index]
        {
            get
            {
                return (T)this.List[index];
            }
        }

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection descriptorCollection = new PropertyDescriptorCollection(null);

            foreach (object obj in List)
            {
                PropertyDescriptor<T> descriptor = new PropertyDescriptor<T>((T)obj);
                descriptorCollection.Add(descriptor);
            }

            return descriptorCollection;
        }
    }
}
