using {{SolutionName}}.Models;

namespace {{SolutionName}}.Repositories
{
    public interface I{{Model.ModelName}}Repository
    {
        {{Model.ModelName}}Model Get(long {{Model.KeyField.Name}});
        int Post({{Model.ModelName}}Model model);
        void Put(long {{Model.KeyField.Name}}, {{Model.ModelName}}Model model);
        void Delete(long {{Model.KeyField.Name}});
    }
}
