using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.Address
{
    public class AddressDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<AddressPersistenceModel>(p => {
                p.ToTable("PartnerAddresses");
                p.HasKey( e => e.Id);
            });
        }
    }
}
