using Juno.AI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Juno.AI.Controllers
{
    [ApiController]
    [Route(Routes.Base)]
    public class BaseController : ControllerBase
    {
        [HttpGet]
        [Route(Routes.BaseHealth)]
        public async Task<IActionResult> Health()
        {
            return Ok(DateTime.Now);
        }
    }
}
