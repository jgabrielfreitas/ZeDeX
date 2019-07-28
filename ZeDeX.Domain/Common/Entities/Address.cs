using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.Domain.Common.Entities
{
    public class Address : EntityBase
    {
        public Point Location { get; set; }
    }
}
