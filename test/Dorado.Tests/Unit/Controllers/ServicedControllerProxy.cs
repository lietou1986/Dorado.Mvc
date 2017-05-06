using Dorado.Controllers;
using Dorado.Services;
using System.Web.Mvc;

namespace Dorado.Tests.Unit.Controllers
{
    public class ServicedControllerProxy : ServicedController<IService>
    {
        public ServicedControllerProxy(IService service)
            : base(service)
        {
        }

        public void BaseOnActionExecuting(ActionExecutingContext context)
        {
            OnActionExecuting(context);
        }
    }
}