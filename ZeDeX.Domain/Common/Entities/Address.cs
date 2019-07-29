using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.Domain.Common.Entities
{
    public class Address : EntityBase
    {
        public IPoint Location { get; set; }
    }
}
