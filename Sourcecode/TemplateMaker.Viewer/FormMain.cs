using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;
using TemplateProcessor.Models;
using TemplateMaker.Viewer.Helpers.CustomProperty;
using TemplateMaker.Viewer.Models;
using TemplateMaker.Viewer.Types;
using TemplateProcessor;
using TemplateMaker.Viewer.Helpers.SmartString;
using TemplateMaker.Viewer.Views;

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
            TemplateManager.Load(@"C:\Dev\DotNet\#Mine\TemplateMaker\Sourcecode\Templates");
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
            propertyGrid.SelectedObject = CurrentProperties;
            propertyGrid.Refresh();

            ShowTemplateParameters();
        }

        private void ShowTemplateParameters()
        {
            try
            {
                richTextBoxParametersJson.Text = JsonConvert.SerializeObject(GetTemplateParameters(), Formatting.Indented);
            }
            catch(MissingDictonaryEntryException ex)
            {
                ThreatInvalidDictionaryEntryException(ex);
            }
            catch(Exception ex)
            {
                if (ex.InnerException is MissingDictonaryEntryException)
                    ThreatInvalidDictionaryEntryException(ex.InnerException as MissingDictonaryEntryException);
            }
        }

        private void ThreatInvalidDictionaryEntryException(MissingDictonaryEntryException ex)
        {
            FormDictionaryEntryEditor formDictionaryEntryEditor = new FormDictionaryEntryEditor(ex.Word);
            formDictionaryEntryEditor.ShowDialog();
            if (formDictionaryEntryEditor.Continue)
                ShowTemplateParameters();
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
            processor.Process(GetTemplateParameters());
        }
    }
}
