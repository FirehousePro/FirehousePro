using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace FAS.FirehousePro.Web.Controllers
{
    public abstract class FirehouseProControllerBase: AbpController
    {
        protected FirehouseProControllerBase()
        {
            LocalizationSourceName = FirehouseProConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}