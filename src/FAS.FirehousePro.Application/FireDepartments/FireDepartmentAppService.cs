using FAS.FirehousePro.Core.FireDepartments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using FAS.FirehousePro.Application.FireDepartments.Dto;
using FAS.FirehousePro.MultiTenancy;
using FAS.FirehousePro.Authorization.Roles;
using FAS.FirehousePro.Editions;
using Abp.AutoMapper;
using FAS.FirehousePro.Users;
using System;

namespace FAS.FirehousePro.Application.FireDepartments
{
    public class FireDepartmentAppService : FirehouseProAppServiceBase, IFireDepartmentAppService
    {
        private readonly IFireDepartmentManager _fireDepartmentManager;
        private readonly RoleManager _roleManager;
        private readonly EditionManager _editionManager;

        public FireDepartmentAppService(
            IFireDepartmentManager fireDepartmentManager,
            RoleManager roleManager,
            EditionManager editionManager)
        {
            _fireDepartmentManager = fireDepartmentManager;
            _roleManager = roleManager;
            _editionManager = editionManager;
        }

        public async Task CreateFireDepartment(CreateFireDepartmentInput input)
        {
            //Create tenant
            var fireDepartment = input.MapTo<FireDepartment>();
            var tenant = new Tenant(input.Domain, input.Name);

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            CheckErrors(await _fireDepartmentManager.CreateFireDepartmentAsync(fireDepartment, tenant));
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new tenant's id.

            //We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                //Create static roles for new tenant
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                await CurrentUnitOfWork.SaveChangesAsync(); //To get static role ids

                //grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                //Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress, User.DefaultPassword);
                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync(); //To get admin user's id

                //Assign admin user to role!
                CheckErrors(await UserManager.AddToRoleAsync(adminUser.Id, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        public void DeleteFireDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FireDepartmentDto> GetFireDepartment(int id)
        {
            var fireDepartment = await _fireDepartmentManager.GetFireDepartmentAsync(id);
            return fireDepartment.MapTo<FireDepartmentDto>();
        }

        public async Task<ListResultDto<FireDepartmentListDto>> GetFireDepartments()
        {
            var fireDepts = await _fireDepartmentManager.GetAllFireDepartments();
            return new ListResultDto<FireDepartmentListDto>(fireDepts.MapTo<List<FireDepartmentListDto>>());
        }

        public Task UpdateFireDepartment(UpdateFireDepartmentInput input)
        {
            throw new NotImplementedException();
        }
    }
}
