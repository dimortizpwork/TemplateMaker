using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateProcessor.Helpers.SmartString.Exceptions
{
    public class MissingDictonaryEntryException : Exception
    {
        public readonly string Word;
        public MissingDictonaryEntryException(string message, string word) : base(message)
        {
            Word = word;
        }
    }
}
