using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZeDeX.AppService.Partner.Command;

namespace ZeDeX.AppService.Partner
{
    public interface IPartnerAppService
    {
        Task CreatePartner(CreatePartnerCommand command);
    }
}
