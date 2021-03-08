using {{SolutionName}}.Models;
using {{SolutionName}}.Repositories;
using {{SolutionName}}.UseCases.Interfaces;

namespace {{SolutionName}}.UseCases
{
    public class Create{{ModelName}} : ICreate{{ModelName}}
    {
        private readonly I{{ModelName}}Repository _{{ModelName}}Repository;
        public Create{{ModelName}}(I{{ModelName}}Repository {{ModelName}}Repository)
        {
            _{{ModelName}}Repository = {{ModelName}}Repository;
        }

        public int Create({{ModelName}}Model model)
        {
            return _{{ModelName}}Repository.Post(model);
        }
    }
}
