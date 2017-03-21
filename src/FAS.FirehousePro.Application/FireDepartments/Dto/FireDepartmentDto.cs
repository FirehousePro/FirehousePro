using FAS.FirehousePro.Application.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Application.FireDepartments.Dto
{
    public class FireDepartmentDto
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public AddressDto Address { get; set; }
    }
}
