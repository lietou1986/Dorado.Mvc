using Dorado.Components.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dorado.Objects
{
    public class AccountResetView : BaseView
    {
        [Required]
        [StringLength(36)]
        public String Token { get; set; }

        [Required]
        [NotTrimmed]
        [StringLength(32)]
        public String NewPassword { get; set; }
    }
}