using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using FAS.FirehousePro.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace FAS.FirehousePro.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FirehousePro.EntityFramework.FirehouseProDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FirehousePro";
        }

        protected override void Seed(FirehousePro.EntityFramework.FirehouseProDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
