using Dorado.Components.Mvc;
using Dorado.Resources.Form;
using Dorado.Tests.Objects;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class MinLengthAdapterTests
    {
        #region MinLengthAdapter(ModelMetadata metadata, ControllerContext context, MinLengthAttribute attribute)

        [Fact]
        public void MinLengthAdapter_SetsErrorMessage()
        {
            MinLengthAttribute attribute = new MinLengthAttribute(128);
            ModelMetadata metadata = new DataAnnotationsModelMetadataProvider()
                .GetMetadataForProperty(null, typeof(AdaptersModel), "MinLength");

            new MinLengthAdapter(metadata, new ControllerContext(), attribute);

            String expected = Validations.MinLength;
            String actual = attribute.ErrorMessage;

            Assert.Equal(expected, actual);
        }

        #endregion MinLengthAdapter(ModelMetadata metadata, ControllerContext context, MinLengthAttribute attribute)
    }
}