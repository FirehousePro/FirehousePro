using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace FAS.FirehousePro.EntityFramework
{
    [DependsOn(
        typeof(FirehouseProCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class FirehouseProEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FirehouseProDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}