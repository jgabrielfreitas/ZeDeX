using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.Domain.Common.Entities
{
    public class Partner : EntityBase
    {
        public string DocumentNumber { get; set; }
        public OwnerEmployee Owner { get; set; }
        public Address Address { get; set; }
        public CoverageArea CoverageArea { get; set; }
    }
}
