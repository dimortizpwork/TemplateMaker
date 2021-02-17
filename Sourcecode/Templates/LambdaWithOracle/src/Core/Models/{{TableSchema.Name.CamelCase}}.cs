using System;

namespace {{ProjectName}}.Core.Models
{
    public class {{TableSchema.Name.CamelCase}}
    {
        {{#each TableSchema.Columns}}
            public {{Type.CSharp}} {{Name.CamelCase}} { get; set; }
        {{/each}}
    }
}
