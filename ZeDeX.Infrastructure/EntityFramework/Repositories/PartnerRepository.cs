﻿using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using System.Linq;
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
            return _context.Partners.Select(e => new Partner
            {
                Id = e.Id,
                DocumentNumber = e.DocumentNumber,
                Address = new Address
                {
                    Id = e.Address.Id,
                    Location = e.Address.Location
                },
                Owner = new OwnerEmployee
                {
                    Id = e.Owner.Id,
                    FirstName = e.Owner.FirstName,
                    LastName = e.Owner.LastName
                },
                CoverageArea = new CoverageArea
                {
                    Id = e.CoverageArea.Id,
                    Location = e.CoverageArea.Location as MultiPolygon
                }
            }).AsQueryable();
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
                    Location = entity.CoverageArea.Location
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
