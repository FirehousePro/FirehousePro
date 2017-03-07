using Abp.Authorization;
using FAS.FirehousePro.Authorization.Roles;
using FAS.FirehousePro.MultiTenancy;
using FAS.FirehousePro.Users;

namespace FAS.FirehousePro.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
