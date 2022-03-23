using Coolblue.Utilities.MonitoringEvents;
using FluentAssertions;
using Moq;
using Serilog;
using Xunit;
using SimpleInjector;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using System.Net;
using {{SolutionName}}.Host.Lambda.Tests.Helpers;
using {{SolutionName}}.UseCases.Interfaces;
using {{SolutionName}}.Lambda.GetAll;
using System.Collections.Generic;
using AutoFixture;

namespace {{SolutionName}}.Host.Lambda.Tests
{
    public class {{Model.ModelName}}GetAllFunctionTests
    {
        private readonly Mock<IGetAll{{Model.ModelName}}> useCase;
        private readonly Function _function;
        private readonly Fixture _fixture;
        private const string HttpMethod = "GET";
        private const string HttpPath = "/{Id}";


        public {{Model.ModelName}}GetAllFunctionTests()
        {
            useCase = new Mock<IGetAll{{Model.ModelName}}>();

            var container = new Container();
            container.RegisterInstance(useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);
            _fixture = new Fixture();
        }

        [Fact]
        public void FunctionHandler_WithValidRequest_WillReturnOk()
        {
            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string>());
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            useCase.Verify(x => x.GetAll(), Times.Once);
        }
    }
}