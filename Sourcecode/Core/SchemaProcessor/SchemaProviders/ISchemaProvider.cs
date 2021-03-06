using SchemaProcessor.Enums;
using SchemaProcessor.Schemas;
using System.Collections.Generic;

namespace SchemaProcessor.SchemaProviders
{
    public interface ISchemaProvider
    {
        ETypeLanguage GetTypeLanguage();
        TableSchema GetTableSchema(string entityName);
        IEnumerable<ColumnSchema> GetColumnsSchema(string entityName);
    }
}
