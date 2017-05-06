using Dorado.Data.Core;
using Dorado.Objects;
using Dorado.Resources.Views.Administration.Roles.RoleView;
using Dorado.Tests.Data;
using Dorado.Validators;
using System;
using System.Linq;
using Xunit;

namespace Dorado.Tests.Unit.Validators
{
    public class RoleValidatorTests : IDisposable
    {
        private RoleValidator validator;
        private TestingContext context;
        private Role role;

        public RoleValidatorTests()
        {
            context = new TestingContext();
            validator = new RoleValidator(new UnitOfWork(context));

            context.DropData();
            role = ObjectFactory.CreateRole();
            context.Set<Role>().Add(role);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        #region CanCreate(RoleView view)

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectFactory.CreateRoleView(1)));
        }

        [Fact]
        public void CanCreate_UsedTitle_ReturnsFalse()
        {
            RoleView view = ObjectFactory.CreateRoleView(1);
            view.Title = role.Title.ToLower();

            Boolean canCreate = validator.CanCreate(view);

            Assert.False(canCreate);
            Assert.Single(validator.ModelState);
            Assert.Equal(Validations.UniqueTitle, validator.ModelState["Title"].Errors.Single().ErrorMessage);
        }

        [Fact]
        public void CanCreate_ValidRole()
        {
            Assert.True(validator.CanCreate(ObjectFactory.CreateRoleView(1)));
        }

        #endregion CanCreate(RoleView view)

        #region CanEdit(RoleView view)

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectFactory.CreateRoleView(role.Id)));
        }

        [Fact]
        public void CanEdit_UsedTitle_ReturnsFalse()
        {
            RoleView view = ObjectFactory.CreateRoleView(1);
            view.Title = role.Title.ToLower();

            Boolean canEdit = validator.CanEdit(view);

            Assert.False(canEdit);
            Assert.Single(validator.ModelState);
            Assert.Equal(Validations.UniqueTitle, validator.ModelState["Title"].Errors.Single().ErrorMessage);
        }

        [Fact]
        public void CanEdit_ValidRole()
        {
            Assert.True(validator.CanEdit(ObjectFactory.CreateRoleView(role.Id)));
        }

        #endregion CanEdit(RoleView view)
    }
}