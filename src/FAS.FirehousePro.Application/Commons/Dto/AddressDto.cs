using Abp.AutoMapper;
using FAS.FirehousePro.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.FirehousePro.Application.Commons.Dto
{
    [AutoMapFrom(typeof(Address))]
    [AutoMapTo(typeof(CreateAddressInput))]
    public class AddressDto
    {
        public string Line1 { get; private set; }

        public string Line2 { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Zip { get; private set; }

        public string County { get; private set; }
    }
}
