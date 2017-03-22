using Abp.AutoMapper;
using FAS.FirehousePro.Application.Commons.Dto;
using FAS.FirehousePro.Core.FireDepartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Application.FireDepartments.Dto
{
    [AutoMapFrom(typeof(FireDepartment))]
    public class FireDepartmentListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public AddressDto Address { get; set; }
    }
}
