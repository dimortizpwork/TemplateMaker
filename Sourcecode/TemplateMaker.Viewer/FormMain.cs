using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;
using TemplateMaker.Service.Models;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Helpers.SmartString;
using TemplateMaker.Viewer.Models;
using TemplateMaker.Viewer.Models.Types;

namespace TemplateMaker.Viewer
{
    public partial class FormMain : Form
    {
        private readonly TemplateManager TemplateManager;
        private PropertyCollection<TemplatePropertyItem> CurrentProperties;
        private Template CurrentTemplate;
        public FormMain()
        {
            InitializeComponent();
            TemplateManager = new TemplateManager();
        }

        private void LoadTemplates()
        {
            TemplateManager.Load(@"C:\Users\alisson.resenderubim\source\repos\TemplateMaker\Templates");
            foreach (Template template in TemplateManager.GetTemplates())
                comboBoxTemplate.Items.Add(template);
            if(comboBoxTemplate.Items.Count > 0)
                comboBoxTemplate.SelectedIndex = 0;
        }

        private void LoadTemplate(Template template)
        {
            CurrentTemplate = template;
            richTextBoxDescription.Text = CurrentTemplate.Description;

            CurrentProperties = new PropertyCollection<TemplatePropertyItem>();
            foreach (TemplateProperty property in CurrentTemplate.Properties)
                CurrentProperties.Add(new TemplatePropertyItem
                {
                    Name = property.Name,
                    Type = property.Type,
                    Required = property.Required,
                    DefaultValue = property.DefaultValue
                });


            var xxx = new TemplatePropertyItem
            {
                Name = "ModelManual",
                Type = ETemplatePropertyType.TableInfo
            };
            xxx.SetValue(new TableInfo
            {
                FullName = new SmartString("VAN_INVOICEREMINDERORDER"),
                Name = new SmartString("INVOICEREMINDERORDER"),
                Prefix = new SmartString("VAN"),
            });
            CurrentProperties.Add(xxx);


            propertyGrid.SelectedObject = CurrentProperties;
            propertyGrid.Refresh();

            ShowTemplateParameters();
        }

        private void ShowTemplateParameters()
        {
            richTextBoxParametersJson.Text = JsonConvert.SerializeObject(GetTemplateParameters(), Formatting.Indented);
        }

        private dynamic GetTemplateParameters()
        {
            IDictionary<string, object> obj = new ExpandoObject();
            foreach (TemplatePropertyItem property in CurrentProperties)
                obj.Add(property.GetName(), property.GetValue());
            return obj;
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

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ShowTemplateParameters();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            var outputPath = Path.Combine(@"C:\Users\alisson.resenderubim\source\repos\TemplateMaker\Output", CurrentTemplate.Name);
            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            TemplateProcessor processor = new TemplateProcessor(CurrentTemplate);
            processor.OnProcessFile += (string filePath, byte[] fileContents) =>
            {
                var outputFilePath = Path.Combine(outputPath, filePath);
                if (!Directory.Exists(Path.GetDirectoryName(outputFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));
                File.WriteAllBytes(outputFilePath, fileContents);
            };
            processor.Process(GetTemplateParameters());
        }
    }
}
