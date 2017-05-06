using System.Collections.Generic;
using System.Web.Mvc;

namespace Dorado.Components.Mvc
{
    public interface IMvcSiteMapProvider
    {
        IEnumerable<MvcSiteMapNode> GetSiteMap(ViewContext context);

        IEnumerable<MvcSiteMapNode> GetBreadcrumb(ViewContext context);
    }
}