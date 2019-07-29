using GeoAPI.Geometries;

namespace ZeDeX.Domain.Common.Entities
{
    public class Address : EntityBase
    {
        public IPoint Location { get; set; }
    }
}
