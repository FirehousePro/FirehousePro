using Abp.Specifications;
using FAS.FirehousePro.MultiTenancy;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public interface IFireDepartmentManager
    {
        Task<IEnumerable<FireDepartment>> GetAllFireDepartments();
        Task<IdentityResult> CreateFireDepartmentAsync(FireDepartment fireDepartment, Tenant tenant);
        Task<FireDepartment> UpdateFireDepartmentAsync(FireDepartment fireDepartment);
        Task<IEnumerable<FireDepartment>> SearchFireDepartmentsAsync(ISpecification<FireDepartment> spec);
        Task<FireDepartment> GetFireDepartmentAsync(int id);
        Task DeleteFireDepartment(int id);
    }
}
