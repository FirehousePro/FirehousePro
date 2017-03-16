using FAS.FirehousePro.Core.FireDepartments;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.EntityFramework.EntityFramework.TypeConfigs
{
    internal class FireDepartmentTypeConfiguration : EntityTypeConfiguration<FireDepartment>
    {
        public FireDepartmentTypeConfiguration()
        {
            Property(t => t.Name)
                .IsRequired();

            Property(t => t.Address.Line1)
                .HasColumnName("AddressLine1");

            Property(t => t.Address.Line2)
                 .HasColumnName("AddressLine2");

            Property(t => t.Address.City)
                 .HasColumnName("City");

            Property(t => t.Address.State)
                 .HasColumnName("State");

            Property(t => t.Address.Zip)
                 .HasColumnName("Zip");

            Property(t => t.Address.County)
                 .HasColumnName("County");
        }
    }
}
