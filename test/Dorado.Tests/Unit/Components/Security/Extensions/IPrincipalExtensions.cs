﻿using Dorado.Components.Security;
using NSubstitute;
using System;
using System.Security.Principal;
using Xunit;
using Xunit.Extensions;

namespace Dorado.Tests.Unit.Components.Security
{
    public class IPrincipalExtensionsTests
    {
        #region Id(this IPrincipal principal)

        [Theory]
        [InlineData("1", 1)]
        [InlineData("", null)]
        [InlineData(null, null)]
        public void Id_ReturnsEntityNameAsInteger(String identity, Int32? id)
        {
            IPrincipal principal = Substitute.For<IPrincipal>();
            principal.Identity.Name.Returns(identity);

            Int32? actual = principal.Id();
            Int32? expected = id;

            Assert.Equal(expected, actual);
        }

        #endregion Id(this IPrincipal principal)
    }
}