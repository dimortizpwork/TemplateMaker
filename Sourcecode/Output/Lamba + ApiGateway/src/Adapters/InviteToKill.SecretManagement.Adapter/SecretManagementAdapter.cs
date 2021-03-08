using System;
using Amazon.KeyManagementService;
using InviteToPay.Ports;
using InviteToPay.SecretManagement.Adapter.InMemory;
using InviteToPay.SecretManagement.Adapter.Kms;
using InviteToPay.ValueTypes;

namespace InviteToPay.SecretManagement.Adapter
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
