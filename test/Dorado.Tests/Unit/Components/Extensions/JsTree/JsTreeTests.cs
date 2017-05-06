using Dorado.Components.Extensions;
using Xunit;

namespace Dorado.Tests.Unit.Components.Extensions
{
    public class JsTreeTests
    {
        #region JsTree()

        [Fact]
        public void JsTree_CreatesEmpty()
        {
            JsTree actual = new JsTree();

            Assert.Empty(actual.Nodes);
            Assert.Empty(actual.SelectedIds);
        }

        #endregion JsTree()
    }
}