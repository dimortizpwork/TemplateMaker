using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using {{SolutionName}}.UseCases;
using {{SolutionName}}.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace {{SolutionName}}.Lambda.GetAll
{
    public class Function : FunctionFromPath
    {
        public Function() : base()
        {
           
        }

        public Function(Container container, bool isUnitTest = false) : base(container, isUnitTest)
        {
        }

        protected override async Task<APIGatewayProxyResponse> ProcessMessageAsync()
        {
            await using var scope = AsyncScopedLifestyle.BeginScope(_container);
            var useCase = scope.GetInstance<IGetAll{{Model.ModelName}}>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(
                () => 
                ApiResponse(statusCode: HttpStatusCode.OK, body: useCase.GetAll())
            );
        }

        public override void RegisterContainer(Container container)
        {
            container.Register<IGetAll{{Model.ModelName}}, GetAll{{Model.ModelName}}>();
        }
    }
}
