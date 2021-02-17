using System;
using System.Collections.Generic;
using System.Text;
using Coolblue.Utilities.Data.Timing;
using Coolblue.Utilities.Resilience.Oracle.Core;
using {{ProjectName}}.Core;
using {{ProjectName}}.Core.Models;

namespace {{ProjectName}}.Oracle.Adapter
{
    public class {{TableSchema.Name.CamelCase}}Repository : OracleDataStoreBase, I{{TableSchema.Name.CamelCase}}Repository
    {
        public {{TableSchema.Name.CamelCase}}Repository(ITimingDbConnection connection, OracleResiliencePolicy resiliencePolicy) : base(connection, resiliencePolicy)
        {
        }

        public string Get{{TableSchema.Name.CamelCase}}()
        {
            return Connection.QueryFirst<string>("select global_name from global_name");
        }
        
    }
}
