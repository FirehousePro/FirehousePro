using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using FAS.FirehousePro.MultiTenancy;
using FAS.FirehousePro.Users;
using Microsoft.AspNet.Identity;
using Abp.Runtime.Session;
using Abp.IdentityFramework;

namespace FAS.FirehousePro
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class FirehouseProAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected FirehouseProAppServiceBase()
        {
            LocalizationSourceName = FirehouseProConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}