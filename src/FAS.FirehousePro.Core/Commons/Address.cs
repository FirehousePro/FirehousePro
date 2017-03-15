using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Core.Commons
{
    public class Address : ValueObject<Address>
    {
        public virtual string Line1 { get; private set; }
        public virtual string Line2 { get; private set; }
        public virtual string City { get; private set; }
        public virtual string State { get; private set; }
        public virtual string Zip { get; private set; }
        public virtual string County { get; private set; }

        public Address(string line1, 
            string line2, 
            string city,
            string state,
            string zip,
            string county)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            Zip = zip;
            County = county;
        }
    }
}
