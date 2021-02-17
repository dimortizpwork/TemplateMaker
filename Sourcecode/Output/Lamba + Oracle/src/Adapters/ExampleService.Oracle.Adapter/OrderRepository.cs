using System;
using System.Collections.Generic;
using System.Text;
using Coolblue.Utilities.Data.Timing;
using Coolblue.Utilities.Resilience.Oracle.Core;
using ExampleService.Core;
using ExampleService.Core.Models;

namespace ExampleService.Oracle.Adapter
{
    public class OrderRepository : OracleDataStoreBase, IOrderRepository
    {
        public OrderRepository(ITimingDbConnection connection, OracleResiliencePolicy resiliencePolicy) : base(connection, resiliencePolicy)
        {
        }

        public string GetOrder()
        {
            return Connection.QueryFirst<string>("select global_name from global_name");
        }
        
    }
}
