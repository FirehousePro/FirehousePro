using Abp.MultiTenancy;
using FAS.FirehousePro.Users;

namespace FAS.FirehousePro.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}