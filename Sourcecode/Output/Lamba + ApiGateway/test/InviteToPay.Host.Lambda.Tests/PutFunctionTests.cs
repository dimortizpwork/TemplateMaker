using Coolblue.Utilities.MonitoringEvents;
using FluentAssertions;
using Moq;
using Serilog;
using Xunit;
using SimpleInjector;
using Coolblue.Utilities.MonitoringEvents.Aws.Lambda.Datadog;
using System.Net;
using InviteToKill.Host.Lambda.Tests.Helpers;
using InviteToKill.UseCases.Interfaces;
using AutoFixture;
using InviteToKill.Host.Lambda.Put;
using InviteToKill.Host.Lambda.Put.Presentations;
using InviteToKill.Models;
using System.Collections.Generic;

namespace InviteToKill.Host.Lambda.Tests
{
    public class PutFunctionTests
    {
        private readonly Mock<IUpdateInviteToPay> _useCase;
        private readonly Function _function;
        private readonly Fixture _fixure;

        const int INVITETOPAYID = 7784;
        const string HTTPMETHOD = "PUT";
        const string HTTPPATH = "/{Id}";

        public PutFunctionTests()
        {
            _useCase = new Mock<IUpdateInviteToPay>();

            var container = new Container();
            container.RegisterInstance(_useCase.Object);

            var logger = new Mock<ILogger>();
            container.RegisterInstance(new MonitoringEvents(logger.Object, new AwsLambdaDatadogMetrics()));
            _function = new Function(container, true);

            _fixure = new Fixture();
        }

        [Fact]
        public void FunctionHandler_WithValidRequest_WillReturnCreated()
        {
            var request = RequestHelper.CreateRequest(HTTPMETHOD, HTTPPATH, new Dictionary<string, string> {
                { "InviteToPayId", INVITETOPAYID.ToString() }
            }, _fixure.Create<BodyRequestModel>());
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            _useCase.Verify(x => x.Update(INVITETOPAYID, It.IsAny<InviteToPayModel>()), Times.Once);
        }

        [Fact]
        public void FunctionHandler_WithInvalidRequest_WillReturnBadRequest()
        {

            _fixure.Customize<BodyRequestModel>(builder =>
                builder.With(x => x.OrderId, -999)
                       .With(x => x.InvoiceId, -999)
            );

            var request = RequestHelper.CreateRequest(HTTPMETHOD, HTTPPATH, new Dictionary<string, string> {
                { "InviteToPayId", INVITETOPAYID.ToString() }
            }, _fixure.Create<BodyRequestModel>());
            var task = _function.FunctionHandler(request, null);

            task.Result.Should().NotBeNull();
            task.Result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            _useCase.Verify(x => x.Update(INVITETOPAYID, It.IsAny<InviteToPayModel>()), Times.Never);
        }
    }
}