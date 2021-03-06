using System;
using System.Collections.Generic;

namespace Repository.MySql

{
    public class SchemaProvider
    {
        private string ConnectionString = @"";

        public T GetTableInfo<T>(string tableName)
        {
            throw new Exception();
        }

        public IEnumerable<T> GetColumnsInfo<T>(string tableName)
        {
            throw new Exception();
        }
    }
}
