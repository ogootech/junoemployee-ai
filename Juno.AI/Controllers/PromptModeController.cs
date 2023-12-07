using Juno.AI.Business.Abstract;
using Juno.AI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Juno.AI.Controllers
{
    [ApiController]
    [Route(Routes.PromptMode)]
    public class PromptModeController : BaseController
    {
        private readonly IPromptModeService promptModeService;

        public PromptModeController(IPromptModeService promptModeService)
        {
            this.promptModeService = promptModeService;
        }

        [HttpGet]
        [Route(Routes.PromptModeGetList)]
        public async Task<IActionResult> GetList()
        {
            return Ok(await promptModeService.GetList());
        }
    }
}
