﻿using Dorado.Components.Mvc;
using Dorado.Resources.Form;
using System;
using Xunit;
using Xunit.Extensions;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class DigitsAttributeTests
    {
        private DigitsAttribute attribute;

        public DigitsAttributeTests()
        {
            attribute = new DigitsAttribute();
        }

        #region DigitsAttribute()

        [Fact]
        public void DigitsAttribute_SetsErrorMessage()
        {
            attribute = new DigitsAttribute();

            String expected = String.Format(Validations.Digits, "Test");
            String actual = attribute.FormatErrorMessage("Test");

            Assert.Equal(expected, actual);
        }

        #endregion DigitsAttribute()

        #region IsValid(Object value)

        [Fact]
        public void IsValid_Null()
        {
            Assert.True(attribute.IsValid(null));
        }

        [Theory]
        [InlineData(12.549)]
        [InlineData("+1402")]
        [InlineData(-2546798)]
        public void IsValid_NotDigits_ReturnsFalse(Object value)
        {
            Assert.False(attribute.IsValid(value));
        }

        [Fact]
        public void IsValid_Digits()
        {
            Assert.True(attribute.IsValid("92233720368547758074878484887777"));
        }

        #endregion IsValid(Object value)
    }
}