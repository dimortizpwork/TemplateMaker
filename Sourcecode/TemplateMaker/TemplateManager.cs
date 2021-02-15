using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TemplateProcessor.Models;

namespace TemplateProcessor
{
    public class TemplateManager
    {
        public static readonly string TemplateFileName = "template.json";

        private IList<Template> Templates = new List<Template>();
        public TemplateManager()
        {

        }

        public void Load(string templatesDirectoryPath)
        {
            Templates.Clear();
            foreach(string directory in Directory.GetDirectories(templatesDirectoryPath))
            {
                string templateFile = Path.Combine(directory, TemplateFileName);
                if (File.Exists(templateFile))
                {
                    Template template = JsonConvert.DeserializeObject<Template>(File.ReadAllText(templateFile));

                    //Fix the SearchDirectory
                    if (string.IsNullOrEmpty(template.SearchDirectory))
                        template.SearchDirectory = directory;
                    if(!Path.IsPathRooted(template.SearchDirectory))
                        template.SearchDirectory = Path.Combine(directory, template.SearchDirectory);

                    Templates.Add(template);
                }
            }
        }

        public IReadOnlyList<Template> GetTemplates()
        {
            return Templates as IReadOnlyList<Template>;
        }        
    }
}
