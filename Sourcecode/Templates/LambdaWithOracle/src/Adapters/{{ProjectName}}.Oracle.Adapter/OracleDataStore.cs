using System;
using Coolblue.Utilities.Data.Timing;
using Gimme.Core.Exceptions;
using Polly.CircuitBreaker;
using OracleResiliencePolicy = Coolblue.Utilities.Resilience.Oracle.Core.OracleResiliencePolicy;

namespace Gimme.Oracle.Adapter
{
    public class OracleDataStoreBase
    {
        private readonly OracleResiliencePolicy _resiliencePolicy;

        protected ITimingDbConnection Connection { get; }

        protected OracleDataStoreBase(ITimingDbConnection connection, OracleResiliencePolicy resiliencePolicy)
        {
            resiliencePolicy = resiliencePolicy ?? throw new ArgumentNullException(nameof(resiliencePolicy));

            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _resiliencePolicy = resiliencePolicy;
        }

        protected T ExecuteWithPolicy<T>(Func<T> func)
        {
            var oraclePolicy = _resiliencePolicy.Value;

            try
            {
                return oraclePolicy.Execute(func);
            }
            catch (BrokenCircuitException ex)
            {
                throw new PersistenceUnavailableException("Oracle circuit breaker is currently open.", ex);
            }
            catch (Exception ex)
            {
                throw new PersistenceException("Exception occurred while executing Oracle query.", ex);
            }
        }

        protected void ExecuteWithPolicy(Action action)
        {
            ExecuteWithPolicy(() =>
            {
                action();
                return 1;
            });

        }
    }
}