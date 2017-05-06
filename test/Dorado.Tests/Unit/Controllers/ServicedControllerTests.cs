using Dorado.Services;
using NSubstitute;
using System;
using Xunit;

namespace Dorado.Tests.Unit.Controllers
{
    public class ServicedControllerTests : ControllerTests
    {
        private ServicedControllerProxy controller;
        private IService service;

        public ServicedControllerTests()
        {
            service = Substitute.For<IService>();
            controller = Substitute.ForPartsOf<ServicedControllerProxy>(service);
        }

        #region ServicedController(TService service)

        [Fact]
        public void ServicedController_SetsService()
        {
            Object actual = controller.Service;
            Object expected = service;

            Assert.Same(expected, actual);
        }

        #endregion ServicedController(TService service)

        #region OnActionExecuting(ActionExecutingContext context)

        [Fact]
        public void OnActionExecuting_SetsServiceCurrentAccountId()
        {
            ReturnCurrentAccountId(controller, 1);

            controller.BaseOnActionExecuting(null);

            Int32 expected = controller.CurrentAccountId;
            Int32 actual = service.CurrentAccountId;

            Assert.Equal(expected, actual);
        }

        #endregion OnActionExecuting(ActionExecutingContext context)

        #region Dispose()

        [Fact]
        public void Dispose_Service()
        {
            controller.Dispose();

            service.Received().Dispose();
        }

        [Fact]
        public void Dispose_MultipleTimes()
        {
            controller.Dispose();
            controller.Dispose();
        }

        #endregion Dispose()
    }
}