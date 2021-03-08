using SchemaProcessor;
using SchemaProcessor.SchemaProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using TemplateMaker.Viewer.Helpers.SchemaProvider;
using TemplateMaker.Viewer.Helpers.SchemaProvider.Exceptions;
using TemplateMaker.Viewer.Models;
using TemplateMaker.Viewer.Types;
using SmartProperty.Editors;
using TemplateProcessor.Models;
using SmartProperty;

namespace TemplateMaker.Views.PropertyEditors
{
    public partial class ObjectPropertyEditor : UserControl, ISmartPropertyEditor
    {
        public ICollection<Property> Value { get; set; }
        public ObjectPropertyEditor()
        {
            InitializeComponent();
        }

        public void SetValue(object value)
        {
            LoadValue(value);
        }

        public object GetValue()
        {
            return Value as IList<IProperty>;
        }

        private void LoadValue(object value)
        {
            if (Value == null)
            {
                Value = new List<Property>();
                foreach(TemplateParameter templateProperty in value as ICollection<TemplateParameter>)
                    Value.Add(new Property(templateProperty));
            }
            smartPropertyGrid1.LoadProperties(Value as IList<IProperty>);
        }
    }
}
