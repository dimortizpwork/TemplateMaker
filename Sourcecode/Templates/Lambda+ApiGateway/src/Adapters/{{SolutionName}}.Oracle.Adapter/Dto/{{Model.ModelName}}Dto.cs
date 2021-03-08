using {{SolutionName}}.Oracle.Adapter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using {{SolutionName}}.Models;

namespace {{SolutionName}}.Oracle.Adapter.Dto
{
    public class {{Model.ModelName}}Dto
    {
        public long {{Model.KeyField}} { get; set; }
        public string UniqueReference { get; set; }

        public static {{Model.ModelName}}Dto FromModel({{Model.ModelName}}Model model)
        {
            return new {{Model.ModelName}}Dto {
                {{Model.KeyField}} = model.{{Model.KeyField}},
                UniqueReference = model.UniqueReference
            };
        }

        public {{Model.ModelName}}Model ToModel()
        {
            return new {{Model.ModelName}}Model {
                {{Model.KeyField}} = {{Model.KeyField}},
                UniqueReference = UniqueReference
            };
        }
    }
}
