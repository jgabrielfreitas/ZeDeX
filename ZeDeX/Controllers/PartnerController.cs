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
            var result = await _appService.CreatePartner(command);
            if (result == null) return UnprocessableEntity();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartner(int id)
        {
            var result = await _appService.GetPartnerById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetNearestPartner([FromQuery] double lat, [FromQuery] double @long)
        {
            var result = await _appService.GetNearestByLocation(lat, @long);
            if (result == null) return NotFound();

            return Ok(result);
        }

    }
}