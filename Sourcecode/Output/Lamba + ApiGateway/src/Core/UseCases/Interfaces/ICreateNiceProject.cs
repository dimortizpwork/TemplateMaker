using SuperNiceProject.Models;

namespace SuperNiceProject.UseCases.Interfaces
{
    public interface ICreateNiceProject
    {
        int Create(NiceProjectModel model);
    }
}
