using System.Collections.Generic;

namespace TemplateMaker.Service.Models
{
    public class Template
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TemplateProperty> Properties { get; set; }
        public string SearchDirectory { get; set; }
        public List<string> SearchFileExtensions { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
