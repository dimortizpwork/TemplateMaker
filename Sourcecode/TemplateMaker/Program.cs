using System;
using System.Windows.Forms;
using TemplateProcessor.Helpers.SmartString;
using TemplateProcessor.Helpers.SmartType;

namespace TemplateMaker.Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SmartStringDictionary.LoadWords();
            SmartTypeDictionary.LoadTypes();
            Application.Run(new FormMain());
        }
    }
}
