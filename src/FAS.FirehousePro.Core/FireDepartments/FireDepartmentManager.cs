using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Organizations;
using FAS.FirehousePro.MultiTenancy;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public class FireDepartmentManager: DomainService, IFireDepartmentManager
    {
        private readonly IRepository<FireDepartment> _fireDepartmentRepo;
        private readonly TenantManager _tenantManager;
        private readonly OrganizationUnitManager _organizationUnitManager;

        public virtual IQueryable<FireDepartment> FireDepartments { get { return _fireDepartmentRepo.GetAll(); } }

        public FireDepartmentManager(IRepository<FireDepartment> fireDepartmentRepo,
            TenantManager tenantManager,
            OrganizationUnitManager organizationUnitManager)
        {
            _fireDepartmentRepo = fireDepartmentRepo;
            _tenantManager = tenantManager;
            _organizationUnitManager = organizationUnitManager;
        }

        public async Task<IdentityResult> CreateFireDepartmentAsync(FireDepartment fireDepartment, Tenant tenant)
        {
            var result = await _tenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync();

            if (result.Succeeded)
            {
                //TODO: Validate Firedepartment

                var org = new OrganizationUnit(tenant.Id, fireDepartment.Name);

                fireDepartment.Tenant = tenant;
                fireDepartment.OrganizationUnit = org;

                await _fireDepartmentRepo.InsertAsync(fireDepartment);
            }

            return result;
        }

        public async Task CreateFireStationAsync(FireStation fireStation)
        {
            throw new NotImplementedException();
        }
    }
}
