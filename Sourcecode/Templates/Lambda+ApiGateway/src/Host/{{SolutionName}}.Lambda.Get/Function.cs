using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.Lambda.Get.Presentations;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Lambda.Get
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
            var useCase = scope.GetInstance<IGet{{Model.ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                var {{Model.ModelName}} = useCase.Get(requestParameters.{{Model.KeyField.Name}});
                if ({{Model.ModelName}} == null)
                    return ApiResponse(statusCode: HttpStatusCode.NotFound, body: null);
                return ApiResponse(statusCode: HttpStatusCode.OK, body: {{Model.ModelName}});
            });
        }

        public override void RegisterContainer(SimpleInjector.Container container)
        {
            container.Register<IGet{{Model.ModelName}}, Get{{Model.ModelName}}>();
        }
    }
}
