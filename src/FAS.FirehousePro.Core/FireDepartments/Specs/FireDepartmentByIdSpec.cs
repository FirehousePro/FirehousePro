using Abp.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.FireDepartments.Specs
{

    /// <summary>
    /// JUST AN EXAMPLE - Change to something meaningful
    /// </summary>
    public class FireDepartmentByIdSpec : Specification<FireDepartment>
    {
        private readonly int _id;

        public FireDepartmentByIdSpec(int id)
        {
            _id = id; 
        }

        public override Expression<Func<FireDepartment, bool>> ToExpression()
        {
            return (fireDepartment) => (fireDepartment.Id == _id);
        }
    }
}
