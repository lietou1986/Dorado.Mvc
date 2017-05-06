using Dorado.Components.Extensions;
using Dorado.Objects;
using Xunit;

namespace Dorado.Tests.Unit.Objects
{
    public class RoleViewTests
    {
        #region RoleView()

        [Fact]
        public void RoleView_CreatesEmpty()
        {
            JsTree actual = new RoleView().Permissions;

            Assert.Empty(actual.SelectedIds);
            Assert.Empty(actual.Nodes);
        }

        #endregion RoleView()
    }
}