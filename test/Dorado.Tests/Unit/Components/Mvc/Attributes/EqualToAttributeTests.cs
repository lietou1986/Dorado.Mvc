using Dorado.Components.Mvc;
using Dorado.Resources.Form;
using Dorado.Tests.Objects;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class EqualToAttributeTests
    {
        private EqualToAttribute attribute;

        public EqualToAttributeTests()
        {
            attribute = new EqualToAttribute("Total");
        }

        #region EqualToAttribute(String otherPropertyName)

        [Fact]
        public void EqualToAttribute_SetsOtherPropertyName()
        {
            String actual = new EqualToAttribute("Other").OtherPropertyName;
            String expected = "Other";

            Assert.Equal(expected, actual);
        }

        #endregion EqualToAttribute(String otherPropertyName)

        #region FormatErrorMessage(String name)

        [Fact]
        public void FormatErrorMessage_ForProperty()
        {
            attribute.OtherPropertyDisplayName = "Other";

            String expected = String.Format(Validations.EqualTo, "Sum", attribute.OtherPropertyDisplayName);
            String actual = attribute.FormatErrorMessage("Sum");

            Assert.Equal(expected, actual);
        }

        #endregion FormatErrorMessage(String name)

        #region IsValid(Object value, ValidationContext context)

        [Fact]
        public void IsValid_EqualValue()
        {
            AttributesModel model = new AttributesModel();
            ValidationContext context = new ValidationContext(model);

            Assert.Null(attribute.GetValidationResult(model.Sum, context));
        }

        [Fact]
        public void IsValid_NotEqualValueMessage()
        {
            AttributesModel model = new AttributesModel { Total = 10 };
            ValidationContext context = new ValidationContext(model);

            String expected = String.Format(Validations.EqualTo, context.DisplayName, "Total");
            String actual = attribute.GetValidationResult(model.Sum, context).ErrorMessage;

            Assert.Equal(expected, actual);
        }

        #endregion IsValid(Object value, ValidationContext context)
    }
}