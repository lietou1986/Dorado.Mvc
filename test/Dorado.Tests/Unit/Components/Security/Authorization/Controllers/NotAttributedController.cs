using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace Dorado.Tests.Unit.Components.Security
{
    [ExcludeFromCodeCoverage]
    public class NotAttributedController : Controller
    {
        [HttpGet]
        public ViewResult Action()
        {
            return null;
        }
    }
}