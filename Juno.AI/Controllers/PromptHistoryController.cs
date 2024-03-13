using Juno.AI.Business.Abstract;
using Juno.AI.Common;
using Juno.AI.Dto;
using Juno.Core.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Juno.AI.Controllers
{
    [ApiController]
    [Route(Routes.PromptHistory)]
    [Route(Routes.PromptHistoryTest)]
    [Route(Routes.PromptHistoryProd)]
    public class PromptHistoryController : BaseController
    {
        private readonly IPromptHistoryService promptHistoryService;
        public PromptHistoryController(IPromptHistoryService promptHistoryService)
        {
            this.promptHistoryService = promptHistoryService;
        }
        [HttpPost]
        [Route(Routes.PromptHistoryGetList)]
        public async Task<IActionResult> CreateFrom([FromBody] PromptHistoryFilterDto request)
        {
            request.TenantId = ClaimHelper.GetTenantId(HttpContext);
            request.Count = request.Count == 0 ? 50 : request.Count;

            return Ok(await promptHistoryService.GetList(request));
        }
    }
}
