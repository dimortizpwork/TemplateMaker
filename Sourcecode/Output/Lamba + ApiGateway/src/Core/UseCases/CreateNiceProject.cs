using SuperNiceProject.Models;
using SuperNiceProject.Repositories;
using SuperNiceProject.UseCases.Interfaces;

namespace SuperNiceProject.UseCases
{
    public class CreateNiceProject : ICreateNiceProject
    {
        private readonly INiceProjectRepository _NiceProjectRepository;
        public CreateNiceProject(INiceProjectRepository NiceProjectRepository)
        {
            _NiceProjectRepository = NiceProjectRepository;
        }

        public int Create(NiceProjectModel model)
        {
            return _NiceProjectRepository.Post(model);
        }
    }
}
