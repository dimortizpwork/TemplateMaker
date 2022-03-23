namespace {{SolutionName}}.Lambda.Get.Presentations
{
    public class ResponseModel
    {
        public long {{Model.KeyField.Name}} { get; set; }
    {{#each Model.Fields}}
        public {{OracleToCSharp Type}} {{Name}} { get; set; } 
    {{/each}}
    }
}
