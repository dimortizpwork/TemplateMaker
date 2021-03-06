using System;

namespace {{ProjectName}}.Core.Models
{
    public class {{CamelCase TableSchema.Name}}
    {
        {{#each TableSchema.Columns}}
            public {{OracleToCSharp Type}} {{CamelCase Name}} { get; set; }
        {{/each}}
    }
}
