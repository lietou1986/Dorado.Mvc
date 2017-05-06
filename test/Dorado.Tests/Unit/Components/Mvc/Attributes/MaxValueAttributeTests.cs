﻿using Dorado.Components.Mvc;
using Dorado.Resources.Form;
using System;
using Xunit;
using Xunit.Extensions;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class MaxValueAttributeTests
    {
        private MaxValueAttribute attribute;

        public MaxValueAttributeTests()
        {
            attribute = new MaxValueAttribute(12.56);
        }

        #region MaxValueAttribute(Double maximum)

        [Fact]
        public void MaxValueAttribute_SetsMaximum()
        {
            Decimal actual = new MaxValueAttribute(12.56).Maximum;
            Decimal expected = 12.56M;

            Assert.Equal(expected, actual);
        }

        #endregion MaxValueAttribute(Double maximum)

        #region FormatErrorMessage(String name)

        [Fact]
        public void FormatErrorMessage_ForName()
        {
            attribute = new MaxValueAttribute(13.44);

            String expected = String.Format(Validations.MaxValue, "Sum", attribute.Maximum);
            String actual = attribute.FormatErrorMessage("Sum");

            Assert.Equal(expected, actual);
        }

        #endregion FormatErrorMessage(String name)

        #region IsValid(Object value)

        [Fact]
        public void IsValid_Null()
        {
            Assert.True(attribute.IsValid(null));
        }

        [Theory]
        [InlineData(12.56)]
        [InlineData("12.559")]
        public void IsValid_LowerOrEqualValue(Object value)
        {
            Assert.True(attribute.IsValid(value));
        }

        [Fact]
        public void IsValid_GreaterValue_ReturnsFalse()
        {
            Assert.False(attribute.IsValid(12.5601));
        }

        [Fact]
        public void IsValid_NotDecimal_ReturnsFalse()
        {
            Assert.False(attribute.IsValid("12.56M"));
        }

        #endregion IsValid(Object value)
    }
}