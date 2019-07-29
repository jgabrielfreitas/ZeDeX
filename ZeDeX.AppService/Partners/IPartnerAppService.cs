using System.Threading.Tasks;
using ZeDeX.AppService.Partners.Command;

namespace ZeDeX.AppService.Partners
{
    public interface IPartnerAppService
    {
        Task CreatePartner(CreatePartnerCommand command);
    }
}
