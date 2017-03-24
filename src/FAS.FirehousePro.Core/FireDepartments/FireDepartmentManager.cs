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
using FAS.FirehousePro.Users;
using FAS.FirehousePro.Authorization.Roles;
using FAS.FirehousePro.Editions;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public class FireDepartmentManager: DomainService, IFireDepartmentManager
    {
        private readonly IFirehoueProRepo<FireDepartment> _fireDepartmentRepo;
        private readonly TenantManager _tenantManager;
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly RoleManager _roleManager;
        private readonly EditionManager _editionManager;
        private readonly UserManager _userManager;
        private readonly IRepository<Tenant> _tenantRepository;

        public FireDepartmentManager(IFirehoueProRepo<FireDepartment> fireDepartmentRepo,
            TenantManager tenantManager,
            OrganizationUnitManager organizationUnitManager,
            RoleManager roleManager,
            EditionManager editionManager,
            UserManager userManager,
            IRepository<Tenant> tenantRepository)
        {
            _fireDepartmentRepo = fireDepartmentRepo;
            _tenantManager = tenantManager;
            _organizationUnitManager = organizationUnitManager;
            _roleManager = roleManager;
            _editionManager = editionManager;
            _userManager = userManager;
            _tenantRepository = tenantRepository;

        }

        public async Task<IdentityResult> CreateFireDepartmentAsync(FireDepartment fireDepartment,
            Tenant tenant,
            string adminEmailAddress,
            string adminPassword)
        {
            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

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

            //We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                //Create static roles for new tenant
                result = await _roleManager.CreateStaticRoles(tenant.Id);

                await CurrentUnitOfWork.SaveChangesAsync(); //To get static role ids

                //grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                //Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, adminEmailAddress, adminPassword);
                result = await _userManager.CreateAsync(adminUser);
                await CurrentUnitOfWork.SaveChangesAsync(); //To get admin user's id

                //Assign admin user to role!
                result = await _userManager.AddToRoleAsync(adminUser.Id, adminRole.Name);
                await CurrentUnitOfWork.SaveChangesAsync();
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

        public async Task<FireDepartment> UpdateFireDepartmentAsync(FireDepartment fireDepartment)
        {
            if (await _tenantRepository.FirstOrDefaultAsync(t => t.TenancyName == fireDepartment.Domain && t.Id != fireDepartment.Tenant.Id) != null)
            {
                throw new InvalidOperationException(string.Format(L("TenancyNameIsAlreadyTaken"), fireDepartment.Domain));
            }

            await _fireDepartmentRepo.UpdateAsync(fireDepartment);

            return fireDepartment;
        }
    }
}
