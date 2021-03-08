using {{SolutionName}}.Models;

namespace {{SolutionName}}.UseCases.Interfaces
{
    public interface IUpdate{{Model.ModelName}}
    {
        void Update(long {{Model.KeyField}}, {{Model.ModelName}}Model model);
    }
}
