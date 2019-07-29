using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeDeX.AppService.Partners.Command;

namespace ZeDeX.AppService.Partners
{
    public interface IPartnerAppService
    {
        Task CreatePartner(CreatePartnerCommand command);
    }
}
