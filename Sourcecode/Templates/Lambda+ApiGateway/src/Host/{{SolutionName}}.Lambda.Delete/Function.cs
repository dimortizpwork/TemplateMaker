using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.Lambda.Delete.Presentations;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Lambda.Delete
{
    public class Function : FunctionFromPath<RequestModel>
    {
        public Function() : base()
        {
        }

        public Function(Container container, bool isUnitTest = false) : base(container, isUnitTest)
        {
        }

        protected override async Task<APIGatewayProxyResponse> ProcessMessageAsync(RequestModel requestParameters)
        {
            await using var scope = AsyncScopedLifestyle.BeginScope(_container);
            var useCase = scope.GetInstance<IDelete{{Model.ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                useCase.Delete(requestParameters.{{Model.KeyField.Name}});
                return ApiResponse(statusCode: HttpStatusCode.OK, body: null);
            });
        }

        public override void RegisterContainer(SimpleInjector.Container container)
        {
            container.Register<IDelete{{Model.ModelName}}, Delete{{Model.ModelName}}>();
        }
    }
}
