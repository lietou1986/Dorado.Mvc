﻿using Dorado.Resources.Form;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dorado.Components.Mvc
{
    public class RequiredAdapter : RequiredAttributeAdapter
    {
        public RequiredAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute)
            : base(metadata, context, attribute)
        {
            Attribute.ErrorMessage = Validations.Required;
        }
    }
}