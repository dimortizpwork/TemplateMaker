using {{SolutionName}}.Repositories;
using {{SolutionName}}.UseCases.Interfaces;

namespace {{SolutionName}}.UseCases
{
    public class Delete{{ModelName}} : IDelete{{ModelName}}
    {
        private readonly I{{ModelName}}Repository _{{ModelName}}Repository;
        public Delete{{ModelName}}(I{{ModelName}}Repository {{ModelName}}Repository)
        {
            _{{ModelName}}Repository = {{ModelName}}Repository;
        }
        public void Delete(long {{ModelName}}Id)
        {
            _{{ModelName}}Repository.Delete({{ModelName}}Id);
        }
    }
}
