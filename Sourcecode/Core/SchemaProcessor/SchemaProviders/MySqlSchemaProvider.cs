using SchemaProcessor.Enums;
using SchemaProcessor.Schemas;
using System;
using System.Collections.Generic;

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

        public ETypeLanguage GetTypeLanguage()
        {
            return ETypeLanguage.MySql;
        }

        public override string ToString()
        {
            return "MySql Schema Provider";
        }
    }
}
