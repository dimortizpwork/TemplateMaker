using SchemaProcessor.Schemas;
using System.Collections.Generic;

namespace SchemaProcessor.SchemaProviders
{
    public interface ISchemaProvider
    {
        TableSchema GetTableSchema(string entityName);
        IEnumerable<ColumnSchema> GetColumnsSchema(string entityName);
    }
}
