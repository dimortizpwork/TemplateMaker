using System.Threading.Tasks;

namespace InviteToKill.Ports
{
    public interface ISecretManagementService
    {
        Task<string> DecryptString(string value);
    }
}
