using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.Emploer
{
    public class EmployerDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<EmployerPersistenceModel>(p => {
                p.ToTable("Emploees");
                p.HasKey(e => e.Id);


                p.HasOne(e => e.Partner).WithOne(o => o.Owner).HasForeignKey<PartnerPersistenceModel>(pp => pp.OwnerId);
            });
            model.Entity<EmployerPersistenceModel>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
