using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZeDeX.Controllers
{
    [Route("v1")]
    [ApiController]
    public abstract class VersionOneController : BlueprintController
    {
    }
}