using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using FAS.FirehousePro.Configuration;

namespace FAS.FirehousePro.Web.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }
    }
}