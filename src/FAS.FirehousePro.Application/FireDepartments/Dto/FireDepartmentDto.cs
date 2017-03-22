using Abp.AutoMapper;
using FAS.FirehousePro.Application.Commons.Dto;
using FAS.FirehousePro.Core.FireDepartments;

namespace FAS.FirehousePro.Application.FireDepartments.Dto
{
    [AutoMapFrom(typeof(FireDepartment))]
    [AutoMapTo(typeof(UpdateFireDepartmentInput))]
    public class FireDepartmentDto
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public AddressDto Address { get; set; }
    }
}
