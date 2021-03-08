using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.Host.Lambda.Delete.Presentations;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Host.Lambda.Delete
{
    public class Function : FunctionFromPath<RequestModel>
    {
        public Function() : base()
        {
        }

        public Function(Container container, bool IsUnitTest = false) : base(container, IsUnitTest)
        {
        }

        protected override async Task<APIGatewayProxyResponse> ProcessMessageAsync(RequestModel requestParameters)
        {
            using var scope = AsyncScopedLifestyle.BeginScope(_container);
            var _useCase = scope.GetInstance<IDelete{{ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                _useCase.Delete(requestParameters.{{ModelName}}Id);
                return ApiResponse(statusCode: HttpStatusCode.OK, body: null);
            });
        }

        public override void RegisterContainer(SimpleInjector.Container container)
        {
            container.Register<IDelete{{ModelName}}, Delete{{ModelName}}>();
        }
    }
}
