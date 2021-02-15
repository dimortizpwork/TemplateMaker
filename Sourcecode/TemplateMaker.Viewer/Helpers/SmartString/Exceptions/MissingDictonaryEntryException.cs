using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMaker.Viewer.Helpers.SmartString
{
    internal class MissingDictonaryEntryException : Exception
    {
        public readonly string Word;
        public MissingDictonaryEntryException(string message, string word) : base(message)
        {
            Word = word;
        }
    }
}
