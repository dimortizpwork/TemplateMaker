using {{SolutionName}}.Models;

namespace {{SolutionName}}.UseCases.Interfaces
{
    public interface IUpdate{{ModelName}}
    {
        void Update(long {{ModelName}}Id, {{ModelName}}Model model);
    }
}
