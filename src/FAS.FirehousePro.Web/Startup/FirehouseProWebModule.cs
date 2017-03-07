using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using FAS.FirehousePro.Configuration;
using FAS.FirehousePro.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;

namespace FAS.FirehousePro.Web.Startup
{
    [DependsOn(
        typeof(FirehouseProApplicationModule), 
        typeof(FirehouseProEntityFrameworkModule), 
        typeof(AbpAspNetCoreModule))]
    public class FirehouseProWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FirehouseProWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(FirehouseProConsts.ConnectionStringName);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<FirehouseProNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(FirehouseProApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}