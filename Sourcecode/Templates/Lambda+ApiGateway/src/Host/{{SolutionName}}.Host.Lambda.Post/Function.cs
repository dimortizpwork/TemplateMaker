using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.Host.Lambda.Post.Presentations;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Host.Lambda.Post
{
    public class Function : FunctionFromBody<RequestModel>
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
            var _useCase = scope.GetInstance<ICreate{{ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                var {{ModelName}}id = _useCase.Create(requestParameters.ToModel());
                return ApiResponse(statusCode: HttpStatusCode.Created, body: new ResponseModel {
                    {{ModelName}}Id = {{ModelName}}id
                });
            });
        }

        public override void RegisterContainer(Container container)
        {
            container.Register<ICreate{{ModelName}}, Create{{ModelName}}>();
        }
    }
}