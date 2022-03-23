using Coolblue.Utilities.MonitoringEvents;
using FluentAssertions;
using Moq;
using Serilog;
using Xunit;
using SimpleInjector;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using System.Net;
using {{SolutionName}}.Host.Lambda.Tests.Helpers;
using {{SolutionName}}.Lambda.Get;
using {{SolutionName}}.Models;
using {{SolutionName}}.UseCases.Interfaces;
using System.Collections.Generic;
using AutoFixture;
using Newtonsoft.Json;

namespace {{SolutionName}}.Host.Lambda.Tests
{
    public class {{Model.ModelName}}GetFunctionTests
    {
        private readonly Mock<IGet{{Model.ModelName}}> _useCase;
        private readonly Function _function;
        private readonly Fixture _fixture;
        private const string HttpMethod = "GET";
        private const string HttpPath = "/{Id}";

        public {{Model.ModelName}}GetFunctionTests()
        {
            _useCase = new Mock<IGet{{Model.ModelName}}>();

            var container = new Container();
            container.RegisterInstance(_useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);
            _fixture = new Fixture();
        }

        [Fact]
        public void FunctionHandler_WithValidRequestNoExistingItem_WillReturnNotFound()
        {
            var valid{{Model.KeyField.Name}} = _fixture.Create<long>();

            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string> {
                { "{{Model.KeyField.Name}}", valid{{Model.KeyField.Name}}.ToString() }
            });
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
            _useCase.Verify(x => x.Get(valid{{Model.KeyField.Name}}), Times.Once);
        }

        [Fact]
        public void FunctionHandler_WithValidRequestExistingItem_WillReturnOK()
        {
            var valid{{Model.KeyField.Name}} = _fixture.Create<long>();

            var returnItem = _fixture.Create<{{Model.ModelName}}Model>();
            _useCase
                .Setup(uc => uc.Get(It.IsAny<long>()))
                .Returns(returnItem);

            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string> {
                { "{{Model.KeyField.Name}}", valid{{Model.KeyField.Name}}.ToString() }
            });

            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            task.Result.Body.Should().NotBeNullOrEmpty();
            var bodyResult = JsonConvert.DeserializeObject<{{Model.ModelName}}Model>(task.Result.Body);
            bodyResult.Should().BeEquivalentTo(returnItem);
            _useCase.Verify(x => x.Get(valid{{Model.KeyField.Name}}), Times.Once);
        }

        [Fact]
        public void FunctionHandler_WithInvalidRequest_WillReturnBadRequest()
        {
            var invalid{{Model.KeyField.Name}} = _fixture.Create<long>();

            var request = RequestHelper.CreateRequest(HttpMethod, HttpPath, new Dictionary<string, string> {
                { _fixture.Create<string>(), invalid{{Model.KeyField.Name}}.ToString() }
            });
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            _useCase.Verify(x => x.Get(invalid{{Model.KeyField.Name}}), Times.Never);
        }
    }
}