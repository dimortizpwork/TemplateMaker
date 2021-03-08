using System.Threading.Tasks;

namespace {{SolutionName}}.Ports
{
    public interface ISecretManagementService
    {
        Task<string> DecryptString(string value);
    }
}
