using Dorado.Components.Security;
using System.Diagnostics.CodeAnalysis;

namespace Dorado.Tests.Unit.Components.Security
{
    [AllowUnauthorized]
    [ExcludeFromCodeCoverage]
    public class AllowUnauthorizedController : AuthorizedController
    {
    }
}