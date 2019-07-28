using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.CoverageArea
{
    public class CoverageAreaDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<CoverageAreaPersistenceModel>(p => {
                p.ToTable("PartnerCoveredAreas");
                p.HasKey(e => e.Id);
            });
        }
    }
}
