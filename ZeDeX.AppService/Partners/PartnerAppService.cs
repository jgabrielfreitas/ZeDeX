using GeoAPI.Geometries;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeDeX.AppService.Partners.Command;
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

        public async Task CreatePartner(CreatePartnerCommand command)
        {

            var partner = new Partner {
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
        }
    }
}
