﻿using Dorado.Components.Mvc;
using System;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class NotTrimmedAttributeTests
    {
        #region GetBinder()

        [Fact]
        public void GetBinder_Default()
        {
            Object actual = new NotTrimmedAttribute().GetBinder();
            Object expected = ModelBinders.Binders.DefaultBinder;

            Assert.Same(expected, actual);
        }

        #endregion GetBinder()
    }
}