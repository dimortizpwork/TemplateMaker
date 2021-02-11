using Coolblue.Utilities.Resilience;
using Gimme.Core.ValueTypes;

namespace Gimme.Host.Lambda
{
    public sealed class LambdaSettings : IOracleSettings
    {
        public ApplicationEnvironment Environment { get; set; }
        public string OracleUserName { get; set; }
        public string OraclePassword { get; set; }
        public string OracleHostName { get; set; }
        public string OracleConnectionString { get; set; }
        public ResilienceSettings OracleResilience { get; set; }

        public string FullConnectionString =>
            OracleConnectionString 
                .Replace("{OracleUserName}", OracleUserName)
                .Replace("{OraclePassword}", OraclePassword)
                .Replace("{OracleHostName}", OracleHostName);
    }
}
