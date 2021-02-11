using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateMaker.Viewer.Helpers;
using TemplateMaker.Viewer.Helpers.SmartString;

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
            SmartStringDictonary.LoadWords();
            Application.Run(new FormMain());
        }
    }
}
