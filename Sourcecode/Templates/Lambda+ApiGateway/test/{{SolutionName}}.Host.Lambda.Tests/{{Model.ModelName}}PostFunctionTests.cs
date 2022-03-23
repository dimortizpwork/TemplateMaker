using Coolblue.Utilities.MonitoringEvents;
using Moq;
using Serilog;
using SimpleInjector;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using {{SolutionName}}.UseCases.Interfaces;
using AutoFixture;
using {{SolutionName}}.Lambda.Post;

namespace {{SolutionName}}.Host.Lambda.Tests
{
    public class {{Model.ModelName}}PostFunctionTests
    {
        private readonly Mock<ICreate{{Model.ModelName}}> useCase;
        private readonly Function _function;
        private readonly Fixture _fixure;

        private const string HttpMethod = "POST";
        private const string HttpPath = "/";

        public {{Model.ModelName}}PostFunctionTests()
        {
            useCase = new Mock<ICreate{{Model.ModelName}}>();

            var container = new Container();
            container.RegisterInstance(useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);

            _fixure = new Fixture();
        }
    }
}