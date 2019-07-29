using GeoAPI.Geometries;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeDeX.Domain.Common.Entities;
using ZeDeX.Domain.Repositories;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Address;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.CoverageArea;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Employer;
using ZeDeX.Infrastructure.EntityFramework.PersistenceModel.Partner;
using ZeDeX.Infrastructure.EntityFramework.Repositories;

namespace ZeDeX.Infrastructure.EntityFramework.RepositoriePartner
{
    public class PartnerRepository : RepositoryBase, IPartnerRepository
    {
        public PartnerRepository(ZedexContext context) : base(context)
        {
        }

        public IQueryable<Partner> All()
        {
            return _context.Partners.Select(partner => ConvertEntityToPersistenceModel(partner)).AsQueryable();
        }

        public async Task<IEnumerable<Partner>> GetNearest(IPoint coordinates)
        {
            var partners = (from p in _context.Partners
                            join pa in _context.PartnerAddresses on p.AddressId equals pa.Id
                            join e in _context.Employees on p.OwnerId equals e.Id
                            join ca in _context.CoverageAreas on p.CoverageAreaId equals ca.Id
                            where ca.Location.Contains(coordinates)
                            select new PartnerPersistenceModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                DocumentNumber = p.DocumentNumber,
                                Address = pa,
                                Owner = e,
                                CoverageArea = ca
                            }).OrderBy(x => x.Address.Location.Distance(coordinates)).Take(10);

            return partners.Select(partner => ConvertEntityToPersistenceModel(partner)).ToList();
        }

        public void Insert(Partner entity)
        {
            var partnerPersistenceModel = new PartnerPersistenceModel
            {
                Owner = new EmployerPersistenceModel
                {
                    IsOwner = entity.Owner.IsOwner,
                    FirstName = entity.Owner.FirstName,
                    LastName = entity.Owner.LastName
                },
                Address = new AddressPersistenceModel
                {
                    Location = entity.Address.Location
                },
                CoverageArea = new CoverageAreaPersistenceModel
                {
                    Location = entity.CoverageArea.Location.Normalized().Reverse()
                },
                DocumentNumber = entity.DocumentNumber,
                Name = entity.Name
            };

            _context.Partners.Add(partnerPersistenceModel);
        }

        public Partner Select(int entityId)
        {
            var partner = (from p in _context.Partners
                           join pa in _context.PartnerAddresses on p.AddressId equals pa.Id
                           join e in _context.Employees on p.OwnerId equals e.Id
                           join ca in _context.CoverageAreas on p.CoverageAreaId equals ca.Id
                           where p.Id == entityId
                           select new PartnerPersistenceModel {
                               Id = p.Id,
                               Name = p.Name,
                               DocumentNumber = p.DocumentNumber,
                               Address = pa,
                               Owner = e,
                               CoverageArea = ca
                           }).FirstOrDefault();

            if (partner == null) return null;

            return ConvertEntityToPersistenceModel(partner);
        }

        private Partner ConvertEntityToPersistenceModel(PartnerPersistenceModel partner)
        {
            return new Partner
            {
                Id = partner.Id,
                DocumentNumber = partner.DocumentNumber,
                Name = partner.Name,
                Address = new Address
                {
                    Id = partner.Address.Id,
                    Location = partner.Address.Location
                },
                Owner = new OwnerEmployee
                {
                    Id = partner.Owner.Id,
                    FirstName = partner.Owner.FirstName,
                    LastName = partner.Owner.LastName
                },
                CoverageArea = new CoverageArea
                {
                    Id = partner.CoverageArea.Id,
                    Location = partner.CoverageArea.Location as MultiPolygon
                }
            };
        }
    }
}
