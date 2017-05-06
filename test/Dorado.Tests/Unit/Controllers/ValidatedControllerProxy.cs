using Dorado.Controllers;
using Dorado.Services;
using Dorado.Validators;
using System.Web.Mvc;

namespace Dorado.Tests.Unit.Controllers
{
    public class ValidatedControllerProxy : ValidatedController<IValidator, IService>
    {
        protected ValidatedControllerProxy(IValidator validator, IService service)
            : base(validator, service)
        {
        }

        public void BaseOnActionExecuting(ActionExecutingContext context)
        {
            OnActionExecuting(context);
        }
    }
}