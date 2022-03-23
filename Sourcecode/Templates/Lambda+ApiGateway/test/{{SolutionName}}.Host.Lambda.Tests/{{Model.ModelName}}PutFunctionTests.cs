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
using AutoFixture;
using {{SolutionName}}.Lambda.Put;
using {{SolutionName}}.Lambda.Put.Presentations;
using {{SolutionName}}.Models;
using System.Collections.Generic;

namespace {{SolutionName}}.Host.Lambda.Tests
{
    public class {{Model.ModelName}}PutFunctionTests
    {
        private readonly Mock<IUpdate{{Model.ModelName}}> useCase;
        private readonly Function _function;
        private readonly Fixture _fixture;
        private const string HttpMethod = "PUT";
        private const string HttpPath = "/{Id}";

        public {{Model.ModelName}}PutFunctionTests()
        {
            useCase = new Mock<IUpdate{{Model.ModelName}}>();

            var container = new Container();
            container.RegisterInstance(useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);

            _fixture = new Fixture();
        }

        [Fact]
        public void FunctionHandler_WithValidRequest_WillReturnCreated()
        {
            var valid{{Model.KeyField.Name}} = _fixture.Create<long>();

            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string> {
                { "{{Model.KeyField.Name}}", valid{{Model.KeyField.Name}}.ToString() }
            }, _fixture.Create<BodyRequestModel>());
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            useCase.Verify(x => x.Update(valid{{Model.KeyField.Name}}, It.IsAny<{{Model.ModelName}}Model>()), Times.Once);
        }
    }
}