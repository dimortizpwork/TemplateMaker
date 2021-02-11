using HandlebarsDotNet;
using System.IO;
using System.Text;
using TemplateMaker.Service.Models;

namespace TemplateMaker
{
    public delegate void TemplateProcessorOnProcessFileHandler(string filePath, byte[] fileContents);
    public class TemplateProcessor
    {
        public TemplateProcessorOnProcessFileHandler OnProcessFile;
        private readonly Template Template;
        public TemplateProcessor(Template template)
        {
            Template = template;
        }

        public void Process(dynamic parameters)
        {
            ProcessDirectory(Template.SearchDirectory, parameters);
        }

        private void ProcessDirectory(string directoryName, dynamic parameters)
        {
            foreach (var file in Directory.GetFiles(directoryName))
                if (!Path.GetFileName(file).Equals(TemplateManager.TemplateFileName))
                    ProcessFile(file, parameters);

            foreach (string directory in Directory.GetDirectories(directoryName))
                ProcessDirectory(directory, parameters);
        }
        private void ProcessFile(string filePath, dynamic parameters)
        {
            //Process the file name
            HandlebarsTemplate<object, object> templateFileName = Handlebars.Compile(filePath.Replace("\\", "//"));
            string processedFileName = templateFileName(parameters);
            processedFileName = processedFileName.Replace("//", "\\");

            if (Template.SearchFileExtensions.IndexOf(Path.GetExtension(filePath)) > 0){
                string fileContents = File.ReadAllText(filePath);
                //Process the file contents
                HandlebarsTemplate<object, object> templateFileContents = Handlebars.Compile(fileContents);
                string processedFileContents = templateFileContents(parameters);

                OnProcessFile?.Invoke(GetTruncateFilePath(processedFileName, Template.SearchDirectory), Encoding.ASCII.GetBytes(processedFileContents));
            }
            else
                OnProcessFile?.Invoke(GetTruncateFilePath(processedFileName, Template.SearchDirectory), File.ReadAllBytes(filePath));          
        }

        private string GetTruncateFilePath(string filePath, string root)
        {
            filePath = filePath.Replace(root, string.Empty);
            if (Path.GetPathRoot(filePath) != string.Empty)
                filePath = filePath.Substring(Path.GetPathRoot(filePath).Length);
            return filePath;
        }
    }
}
