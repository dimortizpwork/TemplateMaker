using SchemaProcessor.SchemaProviders;
using SchemaProcessor.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMaker.Viewer.Types;

namespace TemplateMaker.Viewer.Helpers.SchemaProvider
{
    internal class SchemaProvider
    {
        public static TableInfoType GetTableInfo(ISchemaProvider schemaProvider, string tableName)
        {
            //Append columns
            IList<ColumnInfoType> columns = new List<ColumnInfoType>();
            IEnumerable<ColumnSchema> columnsSchema = schemaProvider.GetColumnsSchema(tableName);
            foreach (ColumnSchema columnSchema in columnsSchema)
            {
                columns.Add(new ColumnInfoType
                {
                    Name = columnSchema.Name
                });
            }

            TableSchema tableSchema = schemaProvider.GetTableSchema(tableName);
            TableInfoType tableInfo = new TableInfoType
            {
                FullName = tableSchema.Name,
                Name = tableSchema.Name.Split('_')[1],
                Prefix = tableSchema.Name.Split('_')[0],
                Columns = columns
            };

            return tableInfo;
        }
    }
}
