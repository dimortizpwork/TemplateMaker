using SuperNiceProject.Models;

namespace SuperNiceProject.UseCases.Interfaces
{
    public interface IUpdateNiceProject
    {
        void Update(long NiceProjectId, NiceProjectModel model);
    }
}
