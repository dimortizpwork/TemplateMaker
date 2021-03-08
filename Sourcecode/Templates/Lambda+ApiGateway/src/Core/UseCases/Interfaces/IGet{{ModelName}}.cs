using {{SolutionName}}.Models;

namespace {{SolutionName}}.UseCases.Interfaces
{
    public interface IGet{{ModelName}}
    {
        {{ModelName}}Model Get(long {{ModelName}}Id);
    }
}
