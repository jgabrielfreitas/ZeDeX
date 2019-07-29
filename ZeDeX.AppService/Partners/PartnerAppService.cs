using GeoAPI.Geometries;
using NetTopologySuite;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeDeX.AppService.Common;
using ZeDeX.AppService.Partners.Command;
using ZeDeX.AppService.Partners.DTOs;
using ZeDeX.Domain.Common;
using ZeDeX.Domain.Common.Entities;
using ZeDeX.Domain.Repositories;
using Address = ZeDeX.Domain.Common.Entities.Address;
using CoverageArea = ZeDeX.Domain.Common.Entities.CoverageArea;

namespace ZeDeX.AppService.Partners
{
    public class PartnerAppService : IPartnerAppService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PartnerAppService(IPartnerRepository partnerRepository, IUnitOfWork unitOfWork)
        {
            _partnerRepository = partnerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PartnerDTO> CreatePartner(CreatePartnerCommand command)
        {
            var partner = new Partner
            {
                DocumentNumber = command.pdv.document,
                Name = command.pdv.name,
                Owner = new OwnerEmployee
                {
                    FirstName = command.owner.firstName,
                    LastName = command.owner.lastName
                },
                Address = new Address
                {
                    Location = command.pdv.address
                },
                CoverageArea = new CoverageArea
                {
                    Location = command.pdv.coverageArea
                }
            };

            _partnerRepository.Insert(partner);
            await _unitOfWork.CommitAsync();

            return ConvertEntityToDTO(partner);
        }

        public async Task<NearbyPartnersDTO> GetNearestByLocation(double lat, double @long)
        {
            var coordinate = GeographyFactory.CreateFactory().CreatePoint(new Coordinate(@long, lat));

            var result = await _partnerRepository.GetNearest(coordinate);
            if (result == null) return null;

            return new NearbyPartnersDTO { Pdvs = result.Select(partner => ConvertEntityToDTO(partner)) };
        }

        public async Task<PartnerDTO> GetPartnerById(int partnerId)
        {
            var partner = _partnerRepository.Select(partnerId);
            if (partner == null) return null;

            return ConvertEntityToDTO(partner);
        }

        private PartnerDTO ConvertEntityToDTO(Partner partner) => new PartnerDTO
        {
            Id = partner.Id,
            Name = partner.Name,
            Address = partner.Address.Location,
            CoverageArea = partner.CoverageArea.Location,
            DocumentNumber = partner.DocumentNumber
        };
    }
}
