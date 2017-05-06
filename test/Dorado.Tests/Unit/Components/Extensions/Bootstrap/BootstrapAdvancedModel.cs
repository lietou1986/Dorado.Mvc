using System;
using System.ComponentModel.DataAnnotations;

namespace Dorado.Tests.Unit.Components.Extensions
{
    public class BootstrapAdvancedModel : BootstrapModel
    {
        [Required]
        public override String NotRequired { get; set; }
    }
}