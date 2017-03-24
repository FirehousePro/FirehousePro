﻿using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using FAS.FirehousePro.MultiTenancy;
using FAS.FirehousePro.Users;
using Abp.MultiTenancy;
using FAS.FirehousePro.Core.FireDepartments;
using FAS.FirehousePro.Application.Commons.Dto;

namespace FAS.FirehousePro.Application.FireDepartments.Dto
{
    [AutoMapTo(typeof(FireDepartment))]
    public class UpdateFireDepartmentInput
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string Domain { get; set; }

        [Required]
        public string Name { get; set; }

        public CreateAddressInput Address { get; set; }
        
    }
}
