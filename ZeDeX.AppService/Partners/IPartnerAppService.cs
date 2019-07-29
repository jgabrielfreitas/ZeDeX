using System.Threading.Tasks;
using ZeDeX.AppService.Partners.Command;
using ZeDeX.AppService.Partners.DTOs;

namespace ZeDeX.AppService.Partners
{
    public interface IPartnerAppService
    {
        Task CreatePartner(CreatePartnerCommand command);
        Task<PartnerDTO> GetPartnerById(int partnerId);
    }
}
