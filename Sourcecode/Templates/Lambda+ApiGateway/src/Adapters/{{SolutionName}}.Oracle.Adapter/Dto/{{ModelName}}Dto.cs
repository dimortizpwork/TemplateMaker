using {{SolutionName}}.Oracle.Adapter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using {{SolutionName}}.Models;

namespace {{SolutionName}}.Oracle.Adapter.Dto
{
    public class {{ModelName}}Dto
    {
        public long {{ModelName}}Id { get; set; }
        public string UniqueReference { get; set; }

        public static {{ModelName}}Dto FromModel({{ModelName}}Model model)
        {
            return new {{ModelName}}Dto {
                {{ModelName}}Id = model.{{ModelName}}Id,
                UniqueReference = model.UniqueReference
            };
        }

        public {{ModelName}}Model ToModel()
        {
            return new {{ModelName}}Model {
                {{ModelName}}Id = {{ModelName}}Id,
                UniqueReference = UniqueReference
            };
        }
    }
}
