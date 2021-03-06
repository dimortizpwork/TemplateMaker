using SchemaProcessor.Enums;
using SchemaProcessor.Schemas;
using System.Collections.Generic;

namespace SchemaProcessor.SchemaProviders
{
    public class OracleSchemaProvider : ISchemaProvider
    {
        private readonly Repository.Oracle.SchemaProvider SchemaProvider;
        public OracleSchemaProvider()
        {
            SchemaProvider = new Repository.Oracle.SchemaProvider();
        }

        public IEnumerable<ColumnSchema> GetColumnsSchema(string entityName)
        {
            return SchemaProvider.GetColumnsInfo<ColumnSchema>(entityName);
        }

        public TableSchema GetTableSchema(string entityName)
        {
            return SchemaProvider.GetTableInfo<TableSchema>(entityName);
        }

        public ETypeLanguage GetTypeLanguage()
        {
            return ETypeLanguage.Oracle;
        }

        public override string ToString()
        {
            return "Oracle Schema Provider";
        }
    }
}
