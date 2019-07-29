using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
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
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartner(int id)
        {
            var result = await _appService.GetPartnerById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}