using SuperNiceProject.Models;
using SuperNiceProject.Repositories;
using SuperNiceProject.UseCases.Interfaces;

namespace SuperNiceProject.UseCases
{
    public class GetNiceProject : IGetNiceProject
    {
        private readonly INiceProjectRepository _NiceProjectRepository;
        public GetNiceProject(INiceProjectRepository NiceProjectRepository)
        {
            _NiceProjectRepository = NiceProjectRepository;
        }

        public NiceProjectModel Get(long NiceProjectId)
        {
            return _NiceProjectRepository.Get(NiceProjectId);
        }
    }
}
