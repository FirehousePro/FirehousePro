using Abp.Application.Services.Dto;
using FAS.FirehousePro.Application.FireDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Application.FireDepartments
{
    public interface IFireDepartmentAppService
    {
        Task<ListResultDto<FireDepartmentListDto>> GetFireDepartments();

        Task<FireDepartmentDto> GetFireDepartment(int id);

        Task CreateFireDepartment(CreateFireDepartmentInput input);

        Task UpdateFireDepartment(UpdateFireDepartmentInput input);

        void DeleteFireDepartment(int id);
    }
}
