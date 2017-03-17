using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using FAS.FirehousePro.Authorization.Roles;
using FAS.FirehousePro.Configuration;
using FAS.FirehousePro.MultiTenancy;
using FAS.FirehousePro.Users;
using FAS.FirehousePro.Web;
using FAS.FirehousePro.Core.FireDepartments;
using System.Data.Entity.ModelConfiguration.Conventions;
using FAS.FirehousePro.EntityFramework.EntityFramework.TypeConfigs;

namespace FAS.FirehousePro.EntityFramework
{
    [DbConfigurationType(typeof(FirehouseProDbConfiguration))]
    public class FirehouseProDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */
        public IDbSet<FireDepartment> FireDepartments { get; set; }

        /* Default constructor is needed for EF command line tool. */
        public FirehouseProDbContext()
            : base(GetConnectionString())
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FireDepartmentTypeConfiguration());
        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                FirehouseProConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of FirehouseProDbContext since ABP automatically handles it.
         */
        public FirehouseProDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public FirehouseProDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public FirehouseProDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    public class FirehouseProDbConfiguration : DbConfiguration
    {
        public FirehouseProDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
