using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.Lambda.Put.Presentations;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Lambda.Put
{
    public class Function : FunctionFromPathAndBody<PathRequestModel, BodyRequestModel>
    {
        public Function() : base()
        {
            
        }

        public Function(Container container, bool isUnitTest = false) : base(container, isUnitTest)
        {
        }

        protected override async Task<APIGatewayProxyResponse> ProcessMessageAsync(PathRequestModel requestParameters, BodyRequestModel requestBody)
        {
            await using var scope = AsyncScopedLifestyle.BeginScope(_container);
            var useCase = scope.GetInstance<IUpdate{{Model.ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                useCase.Update(requestParameters.{{Model.KeyField.Name}}, requestBody.ToModel());
                return ApiResponse(statusCode: HttpStatusCode.OK, body: null);
            });
        }

        public override void RegisterContainer(Container container)
        {
            container.Register<IUpdate{{Model.ModelName}}, Update{{Model.ModelName}}>();
        }
    }
}
