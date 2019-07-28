using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer;

namespace ZeDeX.Infrastructure.EntityFramework.DbMap.Emploer
{
    public class EmployerDbMap : DbMapBase
    {
        public override void ModelBuilder(ModelBuilder model)
        {
            model.Entity<EmployerPersistenceModel>(p => {
                p.ToTable("Emploees");
                p.HasKey(e => e.Id);
            });
        }
    }
}
