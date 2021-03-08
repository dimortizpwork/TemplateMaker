using {{SolutionName}}.Models;
using {{SolutionName}}.Repositories;
using {{SolutionName}}.UseCases.Interfaces;

namespace {{SolutionName}}.UseCases
{
    public class Update{{ModelName}} : IUpdate{{ModelName}}
    {
        private readonly I{{ModelName}}Repository _{{ModelName}}Repository;
        public Update{{ModelName}}(I{{ModelName}}Repository {{ModelName}}Repository)
        {
            _{{ModelName}}Repository = {{ModelName}}Repository;
        }

        public void Update(long {{ModelName}}Id, {{ModelName}}Model model)
        {
            _{{ModelName}}Repository.Put({{ModelName}}Id, model);
        }
    }
}
