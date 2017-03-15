using Abp.Domain.Entities;
using FAS.FirehousePro.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.FireDepartments
{
    public class FireDepartment : Entity<int>
    {
        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<FireStation> FireStations { get; set; }
    }
}
