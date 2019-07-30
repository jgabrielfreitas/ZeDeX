using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.Partner
{
    public class PartnerDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<PartnerPersistenceModel>(p =>
            {
                p.ToTable("Partners");
                p.HasKey(e => e.Id);

                p.HasIndex(e => e.DocumentNumber).IsUnique();

                p.HasOne(e => e.Address).WithOne(v => v.Partner).HasForeignKey<AddressPersistenceModel>(e => e.Id);
                p.HasOne(e => e.Owner).WithOne(v => v.Partner).HasForeignKey<EmployerPersistenceModel>(e => e.Id);
                p.HasOne(e => e.CoverageArea).WithOne(v => v.Partner).HasForeignKey<CoverageAreaPersistenceModel>(e => e.Id);
            });
            model.Entity<PartnerPersistenceModel>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
