using SuperNiceProject.Models;
using SuperNiceProject.Repositories;
using SuperNiceProject.UseCases.Interfaces;

namespace SuperNiceProject.UseCases
{
    public class UpdateNiceProject : IUpdateNiceProject
    {
        private readonly INiceProjectRepository _NiceProjectRepository;
        public UpdateNiceProject(INiceProjectRepository NiceProjectRepository)
        {
            _NiceProjectRepository = NiceProjectRepository;
        }

        public void Update(long NiceProjectId, NiceProjectModel model)
        {
            _NiceProjectRepository.Put(NiceProjectId, model);
        }
    }
}
