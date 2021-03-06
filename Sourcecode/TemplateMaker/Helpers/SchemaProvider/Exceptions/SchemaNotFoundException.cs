using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMaker.Viewer.Helpers.SchemaProvider.Exceptions
{
    public class SchemaNotFoundException: Exception
    {
        public SchemaNotFoundException(string tableName): base($"An error ocurred trying to retrive schema [{tableName}]. Check the name and try again!") { }
    }
}
