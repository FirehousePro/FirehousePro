using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;
using FAS.FirehousePro.Core;
using FAS.FirehousePro.EntityFramework.Repositories;
using Abp.Dependency;
using Castle.MicroKernel.Registration;

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

            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            if (migrator.GetPendingMigrations().Any())
            {
                migrator.Update();
            }

            IocManager.Register(typeof(IFirehoueProRepo<>), typeof(FirehouseProRepo<>), DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}