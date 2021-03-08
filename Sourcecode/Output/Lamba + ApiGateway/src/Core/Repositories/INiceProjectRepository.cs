using SuperNiceProject.Models;

namespace SuperNiceProject.Repositories
{
    public interface INiceProjectRepository
    {
        NiceProjectModel Get(long NiceProjectId);
        int Post(NiceProjectModel model);
        void Put(long NiceProjectId, NiceProjectModel model);
        void Delete(long NiceProjectId);
    }
}
