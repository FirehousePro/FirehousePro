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
        IQueryable<FireDepartment> FireDepartments { get; }

        Task<IdentityResult> CreateFireDepartmentAsync(FireDepartment fireDepartment, Tenant tenant);
        Task CreateFireStationAsync(FireStation fireStation);
    }
}
