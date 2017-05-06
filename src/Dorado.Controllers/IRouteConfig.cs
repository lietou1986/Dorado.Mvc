using System.Web.Routing;

namespace Dorado.Controllers
{
    public interface IRouteConfig
    {
        void RegisterRoutes(RouteCollection routes);
    }
}