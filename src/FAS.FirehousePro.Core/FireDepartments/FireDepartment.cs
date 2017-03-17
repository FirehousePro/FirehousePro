using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using FAS.FirehousePro.Core.Commons;
using FAS.FirehousePro.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public class FireDepartment : FullAuditedEntity<int>, IMustHaveTenant, IMustHaveOrganizationUnit
    {
        public int TenantId { get; set; }
        public virtual long OrganizationUnitId { get; set; }

        public virtual string Name { get; set; }

        public virtual Address Address { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual OrganizationUnit OrganizationUnit { get; set; }

    }
}
