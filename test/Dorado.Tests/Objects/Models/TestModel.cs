using Dorado.Objects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dorado.Tests.Objects
{
    public class TestModel : BaseModel
    {
        [StringLength(128)]
        public String Title { get; set; }
    }
}