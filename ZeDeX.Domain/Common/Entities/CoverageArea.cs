using GeoAPI.Geometries;
using NetTopologySuite.Geometries;

namespace ZeDeX.Domain.Common.Entities
{
    public class CoverageArea : EntityBase
    {
        public MultiPolygon Location { get; set; }
    }
}
