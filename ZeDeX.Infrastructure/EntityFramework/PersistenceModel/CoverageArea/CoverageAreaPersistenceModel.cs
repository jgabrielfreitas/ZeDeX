using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea
{
    public class CoverageAreaPersistenceModel : EntityPersistenceModelBase
    {
        public MultiPolygon Location { get; set; }
        public PartnerPersistenceModel Partner { get; set; }
    }
}
