using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeDeX.Domain.Common;
using ZeDeX.Infrastructure.EntityFramework.DbMap.Address;
using ZeDeX.Infrastructure.EntityFramework.DbMap.CoverageArea;
using ZeDeX.Infrastructure.EntityFramework.DbMap.Emploer;
using ZeDeX.Infrastructure.EntityFramework.DbMap.Partner;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;

namespace ZeDeX.Infrastructure.EntityFramework
{
    public class ZedexContext : DbContext, IUnitOfWork
    {
        public DbSet<AddressPersistenceModel> PartnerAddresses { get; set; }
        public DbSet<CoverageAreaPersistenceModel> CoverageAreas { get; set; }
        public DbSet<EmployerPersistenceModel> Employees { get; set; }
        public DbSet<PartnerPersistenceModel> Partners { get; set; }
        private readonly string _connectionString;

        public ZedexContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PartnerDbMap().ModelBuilder(modelBuilder);
            new AddressDbMap().ModelBuilder(modelBuilder);
            new CoverageAreaDbMap().ModelBuilder(modelBuilder);
            new EmployerDbMap().ModelBuilder(modelBuilder);

        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
