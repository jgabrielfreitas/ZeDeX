using GeoAPI.Geometries;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea
{
    public class CoverageAreaPersistenceModel : EntityPersistenceModelBase
    {
        public IGeometry Location { get; set; }
        public PartnerPersistenceModel Partner { get; set; }
    }
}
