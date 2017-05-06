﻿using Dorado.Components.Mvc;
using Dorado.Tests.Objects;
using System;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class IntegerAdapterTests
    {
        #region GetClientValidationRules()

        [Fact]
        public void GetClientValidationRules_ReturnsIntegerValidationRule()
        {
            ModelMetadata metadata = new DataAnnotationsModelMetadataProvider().GetMetadataForProperty(null, typeof(AdaptersModel), "Integer");
            IntegerAdapter adapter = new IntegerAdapter(metadata, new ControllerContext(), new IntegerAttribute());

            String expectedMessage = new IntegerAttribute().FormatErrorMessage(metadata.GetDisplayName());
            ModelClientValidationRule actual = adapter.GetClientValidationRules().Single();

            Assert.Equal(expectedMessage, actual.ErrorMessage);
            Assert.Equal("integer", actual.ValidationType);
            Assert.Empty(actual.ValidationParameters);
        }

        #endregion GetClientValidationRules()
    }
}