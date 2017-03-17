using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using FAS.FirehousePro.Authorization;
using FAS.FirehousePro.Core.FireDepartments;
using FAS.FirehousePro.Application.FireDepartments.Dto;
using AutoMapper;

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