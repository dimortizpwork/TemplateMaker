using System.Collections.Generic;

namespace SchemaProcessor.Schemas
{
    public class TableSchema
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string FullName { get; set; }
        public IEnumerable<ColumnSchema> Columns { get; set; }
    }
}
