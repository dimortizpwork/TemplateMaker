using System;
using Amazon.KeyManagementService;
using Gimme.Core.Ports;
using Gimme.Core.ValueTypes;
using Gimme.SecretManagement.Adapter.InMemory;
using Gimme.SecretManagement.Adapter.Kms;

namespace Gimme.SecretManagement.Adapter
{
    public static class SecretManagementAdapter
    {
        public static ISecretManagementService GetSecretManagementAdapter(ApplicationEnvironment environment)
        {
            switch (environment)
            {
                case ApplicationEnvironment.Testing:
                case ApplicationEnvironment.Acceptance:
                case ApplicationEnvironment.Production: return new KmsSecretManagementService(new AmazonKeyManagementServiceClient());
                case ApplicationEnvironment.Development: return new InMemorySecretManagementService();
                default: throw new ArgumentOutOfRangeException(nameof(environment), environment, null);
            }
        }
    }
}
