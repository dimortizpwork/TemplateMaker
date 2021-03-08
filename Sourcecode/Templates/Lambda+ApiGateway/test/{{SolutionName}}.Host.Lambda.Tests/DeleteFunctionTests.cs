using Coolblue.Utilities.MonitoringEvents;
using FluentAssertions;
using Moq;
using Serilog;
using System.Collections.Generic;
using Xunit;
using SimpleInjector;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using System.Net;
using {{SolutionName}}.Host.Lambda.Delete;
using {{SolutionName}}.Host.Lambda.Tests.Helpers;
using {{SolutionName}}.UseCases.Interfaces;

namespace {{SolutionName}}.Host.Lambda.Tests
{
    public class DeleteFunctionTests
    {
        private readonly Mock<IDelete{{Model.ModelName}}> _useCase;
        private readonly Function _function;

        const int VALID_ID = 1234;
        const string HTTPMETHOD = "DELETE";
        const string HTTPPATH = "/{Id}";

        public DeleteFunctionTests()
        {
            _useCase = new Mock<IDelete{{Model.ModelName}}>();

            var container = new Container();
            container.RegisterInstance(_useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);
        }

        [Fact]
        public void FunctionHandler_WithValidRequest_WillReturnOK()
        {
            var request = RequestHelper.CreateRequest(HTTPMETHOD, HTTPPATH, new Dictionary<string, string>() {
                {  "{{Model.KeyField}}", $"{VALID_ID}"}
            });
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            _useCase.Verify(x => x.Delete(VALID_{{Model.KeyField}}), Times.Once);
        }

        [Fact]
        public void FunctionHandler_WithInvalidRequest_WillReturnBadRequest()
        {
            var request = RequestHelper.CreateRequest(HTTPMETHOD, HTTPPATH, new Dictionary<string, string>() {
                {  "RandomString", $"{VALID_ID}"}
            });
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

            _useCase.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}