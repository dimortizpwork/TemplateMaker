using SchemaProcessor.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchemaProcessor.SchemaProviders
{
    public class MySqlSchemaProvider : ISchemaProvider
    {
        public IEnumerable<ColumnSchema> GetColumnsSchema(string entityName)
        {
            throw new NotImplementedException();
        }

        public TableSchema GetTableSchema(string entityName)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "MySql Schema Provider";
        }
    }
}
