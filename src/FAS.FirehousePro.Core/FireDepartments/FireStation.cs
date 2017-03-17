using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using FAS.FirehousePro.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public class FireStation: FullAuditedEntity<int>, IMustHaveTenant, IMustHaveOrganizationUnit
    {
        public int TenantId { get; set; }
        public virtual long OrganizationUnitId { get; set; }

        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
        
    }
}
