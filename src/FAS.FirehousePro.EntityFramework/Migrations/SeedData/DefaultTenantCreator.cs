using System.Linq;
using FAS.FirehousePro.EntityFramework;
using FAS.FirehousePro.MultiTenancy;

namespace FAS.FirehousePro.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly FirehouseProDbContext _context;

        public DefaultTenantCreator(FirehouseProDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
