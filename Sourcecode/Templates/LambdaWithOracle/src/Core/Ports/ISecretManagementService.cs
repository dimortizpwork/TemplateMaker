using System.Threading.Tasks;

namespace Gimme.Core.Ports
{
    public interface ISecretManagementService
    {
        Task<string> DecryptString(string value);
    }
}
