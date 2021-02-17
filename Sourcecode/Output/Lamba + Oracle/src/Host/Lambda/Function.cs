using System;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Coolblue.Utilities.MonitoringEvents;
using Gimme.Core;
using Gimme.Core.Models;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Lifestyles;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Gimme.Host.Lambda
{
    public class Function
    {
        private readonly Container _container;

        private readonly MonitoringEvents _monitoringEvents;
        
        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Function() : this(Bootstrapper.CreateDefaultApplication(Bootstrapper.GetLambdaSettings()))
        {
        }

        public Function(Container container)
        {
            container.Verify();
            _container = container;
            _monitoringEvents = container.GetInstance<MonitoringEvents>();
        }

        private APIGatewayProxyResponse ApiResponse(int statusCode, string message)
        {
            return new APIGatewayProxyResponse {
                StatusCode = statusCode,
                Body = message
            };
        }

        (bool FoundProblem, string Message) ValidateRequest(APIGatewayProxyRequest request)
        {
            if (request == null)
                return (true, "Empty request");

            if (string.IsNullOrEmpty(request.Body))
                return (true, "Missing request body");

            if (!request.Body.Contains("PendingPayment"))
                return (true, "Missing PendingPayment in message body");

            return (false, null);
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            // validate input
            var (FoundProblem, Message) = ValidateRequest(request);
            if(FoundProblem)
                return ApiResponse(statusCode: 400, message: Message);

            // process
            var dbName = await ProcessMessageAsync(request);

            // return
            return ApiResponse(
                statusCode: 200,
                message:
                  JsonConvert.SerializeObject(
                    new {
                        dbname = dbName
                    }
            ));
        }


        private struct MessageBody
        {
            public PendingPayment PendingPayment { get; set; }
            public string CorrelationId { get; set; }
        }

        private async Task<string> ProcessMessageAsync(APIGatewayProxyRequest message)
        {
            var correlationId = GetCorrelationId();
            using (_monitoringEvents.LogContext.PushProperty(new LogContextProperty("CorrelationId", correlationId.ToString())))
            {
                using var scope = AsyncScopedLifestyle.BeginScope(_container);
                _monitoringEvents.Logger.Information("Processed message {message}", message);

                var exampleDbCall = scope.GetInstance<IExampleRepository>();
                
                return await Task<string>.Factory.StartNew(() => exampleDbCall.GetDataBaseName());
            }
        }

        private static Guid GetCorrelationId()
        {
            return Guid.NewGuid();
        }
    }
}