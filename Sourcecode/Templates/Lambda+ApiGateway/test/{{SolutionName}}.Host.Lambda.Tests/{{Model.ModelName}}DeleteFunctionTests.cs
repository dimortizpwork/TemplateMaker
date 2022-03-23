using Coolblue.Utilities.MonitoringEvents;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using FluentAssertions;
using Moq;
using Serilog;
using System.Collections.Generic;
using Xunit;
using SimpleInjector;
using System.Net;
using AutoFixture;
using {{SolutionName}}.Lambda.Delete;
using {{SolutionName}}.Host.Lambda.Tests.Helpers;
using {{SolutionName}}.UseCases.Interfaces;

namespace {{SolutionName}}.Host.Lambda.Tests
{
    public class {{Model.ModelName}}DeleteFunctionTests
    {
        private readonly Mock<IDelete{{Model.ModelName}}> useCase;
        private readonly Function _function;
        private readonly Fixture _fixture;

        private const string HttpMethod = "DELETE";
        private const string HttpPath = "/{Id}";

        public {{Model.ModelName}}DeleteFunctionTests()
        {
            useCase = new Mock<IDelete{{Model.ModelName}}>();

            var container = new Container();
            container.RegisterInstance(useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);

            _fixture = new Fixture();
        }

        [Fact]
        public void FunctionHandler_WithValidRequest_WillReturnOK()
        {
            var valid{{Model.KeyField.Name}} = _fixture.Create<long>();
            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string>() {
                {  "{{Model.KeyField.Name}}", valid{{Model.KeyField.Name}}.ToString()}
            });
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            useCase.Verify(x => x.Delete(valid{{Model.KeyField.Name}}), Times.Once);
        }

        [Fact]
        public void FunctionHandler_WithInvalidRequest_WillReturnBadRequest()
        {
            var invalid{{Model.KeyField.Name}} = _fixture.Create<ulong>();

            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string>() {
                {  _fixture.Create<string>(), invalid{{Model.KeyField.Name}}.ToString()}
            });
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

            useCase.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}