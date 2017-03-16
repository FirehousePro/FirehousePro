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
        ListResultDto<FireDepartmentListDto> GetFireDepartments();

        Task CreateFireDepartment(CreateFireDepartmentInput input);
    }
}
