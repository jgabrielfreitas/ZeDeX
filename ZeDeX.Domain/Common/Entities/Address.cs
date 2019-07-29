using GeoAPI.Geometries;
using NetTopologySuite.Geometries;

namespace ZeDeX.Domain.Common.Entities
{
    public class Address : EntityBase
    {
        public Point Location { get; set; }
    }
}
