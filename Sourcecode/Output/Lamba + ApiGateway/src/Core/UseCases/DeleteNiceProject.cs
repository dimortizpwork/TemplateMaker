using SuperNiceProject.Repositories;
using SuperNiceProject.UseCases.Interfaces;

namespace SuperNiceProject.UseCases
{
    public class DeleteNiceProject : IDeleteNiceProject
    {
        private readonly INiceProjectRepository _NiceProjectRepository;
        public DeleteNiceProject(INiceProjectRepository NiceProjectRepository)
        {
            _NiceProjectRepository = NiceProjectRepository;
        }
        public void Delete(long NiceProjectId)
        {
            _NiceProjectRepository.Delete(NiceProjectId);
        }
    }
}
