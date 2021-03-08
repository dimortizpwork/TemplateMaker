using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.Host.Lambda.Get.Presentations;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Host.Lambda.Get
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
            var _useCase = scope.GetInstance<IGet{{ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                var {{ModelName}} = _useCase.Get(requestParameters.{{ModelName}}Id);
                if ({{ModelName}} == null)
                    return ApiResponse(statusCode: HttpStatusCode.NotFound, body: null);
                return ApiResponse(statusCode: HttpStatusCode.OK, body: {{ModelName}});
            });
        }

        public override void RegisterContainer(SimpleInjector.Container container)
        {
            container.Register<IGet{{ModelName}}, Get{{ModelName}}>();
        }
    }
}
