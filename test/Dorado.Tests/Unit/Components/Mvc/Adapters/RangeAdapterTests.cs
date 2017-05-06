using Dorado.Components.Mvc;
using Dorado.Resources.Form;
using Dorado.Tests.Objects;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class RangeAdapterTests
    {
        #region RangeAdapter(ModelMetadata metadata, ControllerContext context, RangeAttribute attribute)

        [Fact]
        public void RangeAdapter_SetsErrorMessage()
        {
            RangeAttribute attribute = new RangeAttribute(0, 128);
            ModelMetadata metadata = new DataAnnotationsModelMetadataProvider()
                .GetMetadataForProperty(null, typeof(AdaptersModel), "Range");

            new RangeAdapter(metadata, new ControllerContext(), attribute);

            String actual = attribute.ErrorMessage;
            String expected = Validations.Range;

            Assert.Equal(expected, actual);
        }

        #endregion RangeAdapter(ModelMetadata metadata, ControllerContext context, RangeAttribute attribute)
    }
}