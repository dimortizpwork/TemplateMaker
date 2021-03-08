using System.Data;
using Coolblue.Utilities.Data.Timing;
using Coolblue.Utilities.Resilience.Oracle.Core;
using Dapper;
using {{SolutionName}}.Models;
using {{SolutionName}}.Oracle.Adapter.Dto;
using {{SolutionName}}.Oracle.Adapter.Helpers;
using {{SolutionName}}.Repositories;

namespace {{SolutionName}}.Oracle.Adapter.Repositories
{
    public class {{Model.ModelName}}Repository : AbstractOracleRepository, I{{Model.ModelName}}Repository
    {
        private const string MonitoringGet = "MonitoringGet";
        private const string MonitoringPost = "MonitoringPost";
        private const string MonitoringPut = "MonitoringPut";
        private const string MonitoringDelete = "MonitoringDelete";

        private const string GetQuery =
           @"select
                INVITETOPAYID,
            {{#each Model.Fields}}
                P_{{UpperCase Name}}{{#unless @last}},{{/unless}}
            {{/each}}
            from table(VAN_PKG_INVITETOPAY.GET(:P_{{UpperCase Model.KeyField.Name}}))";

        private const string PostQuery =
             @"begin
                VAN_PKG_INVITETOPAY.PUT(
                {{#each Model.Fields}}
                    :P_{{UpperCase Name}}{{#unless @last}},{{/unless}}
                {{/each}}
                    :P_{{UpperCase Model.KeyField.Name}})
              end;";
        private const string PutQuery =
            @"begin
                VAN_PKG_INVITETOPAY.PUT(
                {{#each Model.Fields}}
                    :P_{{UpperCase Name}}{{#unless @last}},{{/unless}}
                {{/each}}); 
              end;";

        private const string DeleteQuery =
           @"begin
                VAN_PKG_INVITETOPAY.DELETE(:P_{{UpperCase Model.KeyField.Name}}); 
              end;";

        public {{Model.ModelName}}Repository(ITimingDbConnectionFactory connectionFactory, OracleResiliencePolicy resiliencePolicy) : base(
           connectionFactory, resiliencePolicy)
        {

        }

        public void Delete(long Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_{{UpperCase Model.KeyField.Name}}", Id);

            ExecuteWithPolicy(() => {
                return Connection.Execute("DeleteQuery", DeleteQuery, parameters);
            }, MonitoringDelete);
        }

        public {{Model.ModelName}}Model Get(long Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_{{UpperCase Model.KeyField.Name}}", Id);

            return ExecuteWithPolicy(() => {
                Connection.Open();
                var dto = Connection.QueryFirst<{{Model.ModelName}}Dto>("GetQuery", GetQuery, parameters);
                return dto.ToModel();
            }, MonitoringGet);
        }

        public int Post({{Model.ModelName}}Model model)
        {
            var parameters = new DynamicParameters();
            {{#each Model.Fields}}
                parameters.Add("P_{{UpperCase Name}}", model.{{Name}});
            {{/each}}
            parameters.Add("P_{{ UpperCase Model.KeyField.Name}}", dbType: DbType.Int32, direction: ParameterDirection.Output);

            return ExecuteWithPolicy(() => {
                Connection.Execute("PostQuery", PostQuery, parameters);
                return parameters.Get<int>("P_{{UpperCase Model.KeyField.Name}}");
            }, MonitoringPost);
        }

        public void Put(long Id, {{Model.ModelName}}Model model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("P_{{UpperCase Model.KeyField.Name}}", Id);
            {{#each Model.Fields}}
                parameters.Add("P_{{UpperCase Name}}", model.{{Name}});
            {{/each}}

            ExecuteWithPolicy(() => {
                return Connection.Execute("PutQuery", PutQuery, parameters);
            }, MonitoringPut);
        }
    }
}
