using Dorado.Data.Core;
using Dorado.Objects;
using Dorado.Tests.Objects;
using System.Data.Entity;

namespace Dorado.Tests.Data
{
    public class TestingContext : Context
    {
        #region Test

        protected DbSet<TestModel> TestModels { get; set; }

        #endregion Test

        public void DropData()
        {
            Set<RolePermission>().RemoveRange(Set<RolePermission>());
            Set<Permission>().RemoveRange(Set<Permission>());
            Set<Account>().RemoveRange(Set<Account>());
            Set<Role>().RemoveRange(Set<Role>());

            SaveChanges();
        }
    }
}