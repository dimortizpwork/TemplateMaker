using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SmartProperty;
using TemplateMaker.Viewer.Models;
using TemplateProcessor;
using TemplateProcessor.Models;

namespace TemplateMaker.Viewer.Views
{
    public partial class FormMain : Form
    {
        private readonly TemplateManager TemplateManager;
        private List<IProperty> CurrentProperties;
        private Template CurrentTemplate;
        public FormMain()
        {
            InitializeComponent();
            TemplateManager = new TemplateManager();
        }

        private void LoadTemplates()
        {
            TemplateManager.Load(@"C:\Dev\Templates\TemplateMaker\Sourcecode\Templates");
            foreach (Template template in TemplateManager.GetTemplates())
                comboBoxTemplate.Items.Add(template);
            if(comboBoxTemplate.Items.Count > 0)
                comboBoxTemplate.SelectedIndex = 0;
        }

        private void LoadTemplate(Template template)
        {
            try
            {
                CurrentTemplate = template;
                richTextBoxDescription.Text = CurrentTemplate.Description;
                CurrentProperties = ConvertParameterToProperty(CurrentTemplate.Parameters);
                smartPropertyGrid.LoadProperties(CurrentProperties);

                ShowTemplateParameters();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $@"An error occurred when loading the template `{CurrentTemplate.Name}`: {e.Message}", 
                    @"Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                    );
            }
        }

        private List<IProperty> ConvertParameterToProperty(IEnumerable<TemplateParameter> parameters)
        {
            return parameters
                .Select(parameter => new Property(parameter))
                .Cast<IProperty>()
                .ToList();
        }

        private void ShowTemplateParameters()
        {
            dynamic templateParameters = TemplateParameterProcessor.Process(CurrentTemplate.Parameters);
            richTextBoxParametersJson.Text = JsonConvert.SerializeObject(templateParameters, Formatting.Indented);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            LoadTemplates();
        }

        private void comboBoxTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTemplate.SelectedItem != null)
                LoadTemplate(comboBoxTemplate.SelectedItem as Template);
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            var outputPath = Path.Combine(@"C:\Dev\DotNet\#Mine\TemplateMaker\Sourcecode\Output", CurrentTemplate.Name);
            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            TemplateProcessor.TemplateProcessor processor = new TemplateProcessor.TemplateProcessor(CurrentTemplate);
            processor.OnProcessFile += (string filePath, byte[] fileContents) =>
            {
                var outputFilePath = Path.Combine(outputPath, filePath);
                if (!Directory.Exists(Path.GetDirectoryName(outputFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));
                File.WriteAllBytes(outputFilePath, fileContents);
            };
            processor.OnProcessFileError += (string file, Exception exception) =>
            {
                MessageBox.Show(
                    $@"An error occurred when processing the template at file `{file}`: {exception.Message}", 
                    @"Attention", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                    );
            };
            processor.Process(CurrentTemplate.Parameters);
        }

        private void smartPropertyGrid_PropertyValueChanged(IProperty property)
        {
            ShowTemplateParameters();
        }
    }
}
