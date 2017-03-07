using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using FAS.FirehousePro.Configuration;
using FAS.FirehousePro.EntityFramework;

namespace FAS.FirehousePro.Migrator
{
    [DependsOn(typeof(FirehouseProEntityFrameworkModule))]
    public class FirehouseProMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FirehouseProMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(FirehouseProMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<FirehouseProDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FirehouseProConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}