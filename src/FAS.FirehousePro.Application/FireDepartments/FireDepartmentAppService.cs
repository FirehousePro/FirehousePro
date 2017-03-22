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
using FAS.FirehousePro.Core.Commons;

namespace FAS.FirehousePro.Application.FireDepartments
{
    public class FireDepartmentAppService : FirehouseProAppServiceBase, IFireDepartmentAppService
    {
        private readonly IFireDepartmentManager _fireDepartmentManager;

        public FireDepartmentAppService(IFireDepartmentManager fireDepartmentManager)
        {
            _fireDepartmentManager = fireDepartmentManager;
            
        }

        public async Task CreateFireDepartment(CreateFireDepartmentInput input)
        {
            var fireDepartment = input.MapTo<FireDepartment>();
            var tenant = new Tenant(input.Domain, input.Name);

            CheckErrors(await _fireDepartmentManager.CreateFireDepartmentAsync(fireDepartment, tenant, input.AdminEmailAddress, input.AdminPassword));
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

        public async Task UpdateFireDepartment(UpdateFireDepartmentInput input)
        {
            var fireDept = await _fireDepartmentManager.GetFireDepartmentAsync(input.Id);

            if (fireDept == null)
                throw new InvalidOperationException("Could not find fire department to update");

            fireDept.Name = input.Name;
            fireDept.ChangeDomain(input.Domain);

            var address = input.Address.MapTo<Address>();

            if (fireDept.Address != address)
                fireDept.Address = address;

            await _fireDepartmentManager.UpdateFireDepartmentAsync(fireDept);
        }
    }
}
