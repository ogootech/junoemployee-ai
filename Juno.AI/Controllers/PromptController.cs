using Juno.AI.Business.Abstract;
using Juno.AI.Common;
using Juno.AI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Juno.AI.Controllers
{
    [ApiController]
    [Route(Routes.Prompt)]
    public class PromptController : BaseController
    {
        private readonly IPromptService promptService;
        public PromptController(IPromptService promptService)
        {
            this.promptService = promptService;
        }
        [HttpPost]
        [Route(Routes.PromptSend)]
        public async Task<IActionResult> Send([FromBody] PromptSendRequestDto request)
        {
            return Ok(await promptService.Send(request.Message));
        }
    }
}
