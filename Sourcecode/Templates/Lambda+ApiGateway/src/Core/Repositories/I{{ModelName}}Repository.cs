using {{SolutionName}}.Models;

namespace {{SolutionName}}.Repositories
{
    public interface I{{ModelName}}Repository
    {
        {{ModelName}}Model Get(long {{ModelName}}Id);
        int Post({{ModelName}}Model model);
        void Put(long {{ModelName}}Id, {{ModelName}}Model model);
        void Delete(long {{ModelName}}Id);
        void Send(long {{ModelName}}Id, long UserId, string Recipient);
    }
}
