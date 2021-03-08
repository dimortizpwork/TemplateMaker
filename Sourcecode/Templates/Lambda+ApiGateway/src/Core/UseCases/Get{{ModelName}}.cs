using {{SolutionName}}.Models;
using {{SolutionName}}.Repositories;
using {{SolutionName}}.UseCases.Interfaces;

namespace {{SolutionName}}.UseCases
{
    public class Get{{ModelName}} : IGet{{ModelName}}
    {
        private readonly I{{ModelName}}Repository _{{ModelName}}Repository;
        public Get{{ModelName}}(I{{ModelName}}Repository {{ModelName}}Repository)
        {
            _{{ModelName}}Repository = {{ModelName}}Repository;
        }

        public {{ModelName}}Model Get(long {{ModelName}}Id)
        {
            return _{{ModelName}}Repository.Get({{ModelName}}Id);
        }
    }
}
