using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using FAS.FirehousePro.Authorization;

namespace FAS.FirehousePro
{
    [DependsOn(
        typeof(FirehouseProCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FirehouseProApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FirehouseProAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}