﻿using Dorado.Components.Mvc;
using Dorado.Tests.Objects;
using NSubstitute;
using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using Xunit;

namespace Dorado.Tests.Unit.Components.Mvc
{
    public class TrimmingModelBinderTests
    {
        private ControllerContext controllerContext;
        private ModelBindingContext bindingContext;
        private NameValueCollection collection;
        private TrimmingModelBinder binder;

        public TrimmingModelBinderTests()
        {
            controllerContext = new ControllerContext();
            bindingContext = new ModelBindingContext();
            bindingContext.ModelName = "StringField";
            collection = new NameValueCollection();
            binder = new TrimmingModelBinder();

            controllerContext.Controller = Substitute.For<ControllerBase>();
            bindingContext.ModelMetadata = new DataAnnotationsModelMetadataProvider()
                .GetMetadataForProperty(null, typeof(AllTypesView), "StringField");
        }

        #region BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)

        [Fact]
        public void BindModel_NullValue_ReturnsNull()
        {
            bindingContext.ValueProvider = new NameValueCollectionValueProvider(collection, null);

            Assert.Null(binder.BindModel(controllerContext, bindingContext));
        }

        [Fact]
        public void BindModel_NullAttemptedValue_ReturnsNull()
        {
            collection.Add(bindingContext.ModelName, null);
            bindingContext.ValueProvider = new NameValueCollectionValueProvider(collection, null);

            Assert.Null(binder.BindModel(controllerContext, bindingContext));
        }

        [Fact]
        public void BindModel_DoesNotTrimValue()
        {
            bindingContext.ModelName = "NotTrimmedStringField";
            collection.Add(bindingContext.ModelName, "  Trimmed text  ");
            bindingContext.ValueProvider = new NameValueCollectionValueProvider(collection, null);
            bindingContext.ModelMetadata = new DataAnnotationsModelMetadataProvider()
                .GetMetadataForProperty(null, typeof(AllTypesView), "NotTrimmedStringField");

            Object actual = binder.BindModel(controllerContext, bindingContext);
            Object expected = "  Trimmed text  ";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BindModel_TrimsValue()
        {
            collection.Add(bindingContext.ModelName, "  Trimmed text  ");
            bindingContext.ValueProvider = new NameValueCollectionValueProvider(collection, null);

            Object actual = binder.BindModel(controllerContext, bindingContext);
            Object expected = "Trimmed text";

            Assert.Equal(expected, actual);
        }

        #endregion BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    }
}