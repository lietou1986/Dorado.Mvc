﻿using Dorado.Components.Mvc;
using Dorado.Objects;
using Dorado.Resources.Form;
using System;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class NumberValidatorTests
    {
        private NumberValidator validator;
        private ModelMetadata metadata;

        public NumberValidatorTests()
        {
            metadata = new DisplayNameMetadataProvider().GetMetadataForProperty(null, typeof(AccountView), "Username");
            validator = new NumberValidator(metadata, new ControllerContext());
        }

        #region Validate(Object container)

        [Fact]
        public void Validate_ReturnsEmpty()
        {
            Assert.Empty(validator.Validate(null));
        }

        #endregion Validate(Object container)

        #region GetClientValidationRules()

        [Fact]
        public void GetClientValidationRules_ReturnsNumberValidationRule()
        {
            ModelClientValidationRule actual = validator.GetClientValidationRules().Single();
            ModelClientValidationRule expected = new ModelClientValidationRule
            {
                ValidationType = "number",
                ErrorMessage = String.Format(Validations.Numeric, metadata.GetDisplayName())
            };

            Assert.Equal(expected.ValidationParameters, actual.ValidationParameters);
            Assert.Equal(expected.ValidationType, actual.ValidationType);
            Assert.Equal(expected.ErrorMessage, actual.ErrorMessage);
        }

        #endregion GetClientValidationRules()
    }
}