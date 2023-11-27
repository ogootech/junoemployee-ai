using Juno.AI.Business.Abstract;
using Juno.AI.Common;
using Juno.AI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Juno.AI.Controllers
{
    [ApiController]
    [Route(Routes.Visual)]
    public class VisualController : BaseController
    {
        private readonly IVisualService visualService;
        public VisualController(IVisualService visualService)
        {
            this.visualService = visualService;
        }
        [HttpPost]
        [Route(Routes.VisualGenerateImage)]
        public async Task<IActionResult> GenerateImage([FromBody] VisualGenerateRequestDto request)
        {
            return Ok(await visualService.GenerateImage(request));
        }
    }
}
