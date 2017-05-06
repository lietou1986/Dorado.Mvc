using Dorado.Objects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dorado.Tests.Objects
{
    public class TestView : BaseView
    {
        [StringLength(128)]
        public String Title { get; set; }
    }
}