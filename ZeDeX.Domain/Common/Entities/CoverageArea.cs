using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeDeX.Domain.Common.Entities
{
    public class CoverageArea : EntityBase
    {
        public MultiPolygon Location { get; set; }
    }
}
