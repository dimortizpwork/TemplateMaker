using System.Collections.Generic;
using System.Dynamic;
using TemplateProcessor.Models;

namespace TemplateProcessor
{
    public class TemplateParameterProcessor
    {
        public static dynamic Process(IEnumerable<TemplateParameter> properties)
        {
            IDictionary<string, object> obj = new ExpandoObject();
            foreach (TemplateParameter property in properties)
                ProcessProperty(obj, property);
            return obj;
        }

        private static void ProcessProperty(IDictionary<string, object> dictonary, TemplateParameter property)
        {
            dictonary.Add(property.Name, property.Value);
        }
    }
}
