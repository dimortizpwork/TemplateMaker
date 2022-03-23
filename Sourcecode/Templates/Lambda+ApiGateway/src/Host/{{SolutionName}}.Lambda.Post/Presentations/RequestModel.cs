using {{SolutionName}}.Models;
using Lambda.Base.Presentations;

namespace {{SolutionName}}.Lambda.Post.Presentations
{
    public class RequestModel: IRequestModel
    {
    {{#each Model.Fields}}
        public {{OracleToCSharp Type}} {{Name}} { get; set; } 
    {{/each}}

        public {{Model.ModelName}}Model ToModel()
        {
            return new {{Model.ModelName}}Model {
            {{#each Model.Fields}}
                {{Name}} = {{Name}}{{#unless @last}},{{/unless}}
            {{/each}}
            };
        }

        public void Validate()
        {
        }
    }
}
