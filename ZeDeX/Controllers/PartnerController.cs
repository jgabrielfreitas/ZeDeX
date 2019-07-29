using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeDeX.AppService.Partners;
using ZeDeX.AppService.Partners.Command;

namespace ZeDeX.Controllers
{
    [Route("api/v1/partners")]
    public class PartnerController : ZedexBaseController
    {
        private readonly IPartnerAppService _appService;

        public PartnerController(IPartnerAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner([FromBody] CreatePartnerCommand command)
        {
            await _appService.CreatePartner(command);
            return Ok();
        }
    }
}