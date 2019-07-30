using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.CoverageArea
{
    public class CoverageAreaDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<CoverageAreaPersistenceModel>(p =>
            {
                p.ToTable("PartnerCoveredAreas");
                p.HasKey(e => e.Id);

                p.HasOne(e => e.Partner).WithOne(o => o.CoverageArea).HasForeignKey<PartnerPersistenceModel>(pp => pp.CoverageAreaId);
            });
            model.Entity<CoverageAreaPersistenceModel>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
