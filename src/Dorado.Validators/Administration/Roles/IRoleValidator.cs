using Dorado.Objects;
using System;

namespace Dorado.Validators
{
    public interface IRoleValidator : IValidator
    {
        Boolean CanCreate(RoleView view);

        Boolean CanEdit(RoleView view);
    }
}