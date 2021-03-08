using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using InviteToKill.Host.Lambda.Get.Presentations;
using InviteToKill.UseCases;
using InviteToKill.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace InviteToKill.Host.Lambda.Get
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
            var _useCase = scope.GetInstance<IGetInviteToKill>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                var InviteToKill = _useCase.Get(requestParameters.InviteToKillId);
                if (InviteToKill == null)
                    return ApiResponse(statusCode: HttpStatusCode.NotFound, body: null);
                return ApiResponse(statusCode: HttpStatusCode.OK, body: InviteToKill);
            });
        }

        public override void RegisterContainer(SimpleInjector.Container container)
        {
            container.Register<IGetInviteToKill, GetInviteToKill>();
        }
    }
}
