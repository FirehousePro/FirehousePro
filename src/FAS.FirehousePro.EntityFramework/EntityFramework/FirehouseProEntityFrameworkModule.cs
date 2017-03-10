using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FAS.FirehousePro.EntityFramework
{
    [DependsOn(
        typeof(FirehouseProCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class FirehouseProEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FirehouseProDbContext, Migrations.Configuration>());


            //var configuration = new Migrations.Configuration();
            //var migrator = new DbMigrator(configuration);
            //if (migrator.GetPendingMigrations().Any())
            //{
            //    migrator.Update();
            //}
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}