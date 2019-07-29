using GeoAPI.Geometries;

namespace ZeDeX.Domain.Common.Entities
{
    public class CoverageArea : EntityBase
    {
        public IMultiPolygon Location { get; set; }
    }
}
