using System;
using System.Collections.Generic;
using System.Text;
using Coolblue.Utilities.Data.Timing;
using Coolblue.Utilities.Resilience.Oracle.Core;
using Gimme.Core;
using Gimme.Core.Models;

namespace Gimme.Oracle.Adapter
{
    public class ExampleRepository : OracleDataStoreBase, IExampleRepository
    {
        public ExampleRepository(ITimingDbConnection connection, OracleResiliencePolicy resiliencePolicy) : base(connection, resiliencePolicy)
        {
        }

        public string GetDataBaseName()
        {
            return Connection.QueryFirst<string>("sample query", "select global_name from global_name");
        }
    }
}
