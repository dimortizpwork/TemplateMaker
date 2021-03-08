using SuperNiceProject.Models;

namespace SuperNiceProject.UseCases.Interfaces
{
    public interface IGetNiceProject
    {
        NiceProjectModel Get(long NiceProjectId);
    }
}
