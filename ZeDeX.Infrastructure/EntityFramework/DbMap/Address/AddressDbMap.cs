using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.Address
{
    public class AddressDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<AddressPersistenceModel>(p => {
                p.ToTable("PartnerAddresses");
                p.HasKey( e => e.Id);

                p.HasOne(e => e.Partner).WithOne(o => o.Address).HasForeignKey<PartnerPersistenceModel>(pp => pp.AddressId);
            });
            model.Entity<AddressPersistenceModel>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
