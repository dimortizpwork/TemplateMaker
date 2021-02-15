using SchemaProcessor.SchemaProviders;
using System;
using System.Collections.Generic;
using SchemaProcessor.SchemaProviders;

namespace SchemaProcessor
{
    public class SchemaProviderManager
    {
        private readonly List<ISchemaProvider> SchemaProviders;

        public SchemaProviderManager()
        {
            SchemaProviders = new List<ISchemaProvider>
            {
                new OracleSchemaProvider(),
                new MySqlSchemaProvider(),
            };
        }

        public List<ISchemaProvider> GetProviders()
        {
            return SchemaProviders;
        }
    }
}
