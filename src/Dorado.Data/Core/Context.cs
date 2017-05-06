using Dorado.Data.Mapping;
using Dorado.Objects;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Dorado.Data.Core
{
    public class Context : DbContext
    {
        #region Administration

        protected DbSet<Role> Roles { get; set; }
        protected DbSet<Account> Accounts { get; set; }
        protected DbSet<Permission> Permissions { get; set; }
        protected DbSet<RolePermission> RolePermissions { get; set; }

        #endregion Administration

        #region System

        protected DbSet<AuditLog> AuditLogs { get; set; }

        #endregion System

        static Context()
        {
            ObjectMapper.MapObjects();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            builder.Properties<DateTime>().Configure(config => config.HasColumnType("datetime2"));
            builder.Entity<Permission>().Property(model => model.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}