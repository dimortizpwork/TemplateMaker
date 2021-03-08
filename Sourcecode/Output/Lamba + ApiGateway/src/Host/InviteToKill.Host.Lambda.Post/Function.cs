using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using InviteToKill.Host.Lambda.Post.Presentations;
using InviteToKill.UseCases;
using InviteToKill.UseCases.Interfaces;
using Lambda.Base;
using SimpleInjector;
using SimpleInjector.Lifestyles;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace InviteToKill.Host.Lambda.Post
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
            var _useCase = scope.GetInstance<ICreateInviteToKill>();

            return await Task<APIGatewayProxyResponse>.Factory.StartNew(() => {
                var InviteToKillid = _useCase.Create(requestParameters.ToModel());
                return ApiResponse(statusCode: HttpStatusCode.Created, body: new ResponseModel {
                    InviteToKillId = InviteToKillid
                });
            });
        }

        public override void RegisterContainer(Container container)
        {
            container.Register<ICreateInviteToKill, CreateInviteToKill>();
        }
    }
}
