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
using Abp.Specifications;
using FAS.FirehousePro.Core.FireDepartments.Specs;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public class FireDepartmentManager: DomainService, IFireDepartmentManager
    {
        private readonly IFirehoueProRepo<FireDepartment> _fireDepartmentRepo;
        private readonly TenantManager _tenantManager;
        private readonly OrganizationUnitManager _organizationUnitManager;

        public FireDepartmentManager(IFirehoueProRepo<FireDepartment> fireDepartmentRepo,
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
                await _organizationUnitManager.CreateAsync(org);
                await CurrentUnitOfWork.SaveChangesAsync();

                fireDepartment.Tenant = tenant;
                fireDepartment.TenantId = tenant.Id;
                fireDepartment.OrganizationUnitId = org.Id;
                fireDepartment.OrganizationUnit = org;

                if(fireDepartment.Address == null)
                {
                    fireDepartment.Address = new Commons.Address();
                }

                await _fireDepartmentRepo.InsertAsync(fireDepartment);
            }

            return result;
        }

        public async Task<IEnumerable<FireDepartment>> SearchFireDepartmentsAsync(ISpecification<FireDepartment> spec)
        {
            return await _fireDepartmentRepo.GetAllListAsync(spec.ToExpression());
        }

        public async Task<FireDepartment> GetFireDepartmentAsync(int id)
        {
            return await _fireDepartmentRepo.GetWithAsync(id, f => f.Tenant);
        }

        public async Task DeleteFireDepartment(int id)
        {
            await _fireDepartmentRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<FireDepartment>> GetAllFireDepartments()
        {
            return await _fireDepartmentRepo.GetAllListWithAsync(f => f.Tenant);
        }

        public Task<FireDepartment> UpdateFireDepartmentAsync(FireDepartment fireDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
