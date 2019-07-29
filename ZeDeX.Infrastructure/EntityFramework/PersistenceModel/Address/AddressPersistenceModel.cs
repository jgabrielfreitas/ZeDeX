using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address
{
    public class AddressPersistenceModel : EntityPersistenceModelBase
    {
        public Point Location { get; set; }

        public PartnerPersistenceModel Partner { get; set; }
    }
}
