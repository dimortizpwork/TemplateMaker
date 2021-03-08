using System.Threading.Tasks;
using InviteToPay.Ports;

namespace InviteToPay.SecretManagement.Adapter.InMemory
{
    internal sealed class InMemorySecretManagementService : ISecretManagementService
    {
        public Task<string> DecryptString(string value)
        {
            return Task.FromResult(value);
        }
    }
}
