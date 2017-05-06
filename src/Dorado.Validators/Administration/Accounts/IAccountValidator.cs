using Dorado.Objects;
using System;

namespace Dorado.Validators
{
    public interface IAccountValidator : IValidator
    {
        Boolean CanRecover(AccountRecoveryView view);

        Boolean CanReset(AccountResetView view);

        Boolean CanLogin(AccountLoginView view);

        Boolean CanCreate(AccountCreateView view);

        Boolean CanEdit(AccountEditView view);

        Boolean CanEdit(ProfileEditView view);

        Boolean CanDelete(ProfileDeleteView view);
    }
}