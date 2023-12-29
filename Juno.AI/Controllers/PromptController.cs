using Amazon.Runtime.Internal;
using Juno.AI.Business.Abstract;
using Juno.AI.Common;
using Juno.AI.Dto;
using Juno.Core.Helper;
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
        [Route(Routes.PromptCreate)]
        public async Task<IActionResult> Create([FromBody] PromptCreateRequestDto request)
        {
            request.TenantId = ClaimHelper.GetTenantId(HttpContext);
            request.UserId = ClaimHelper.GetUserId(HttpContext);

            request.TitleSize = 250;
            request.DescriptionSize = 500;
            request.ContentSize = 10000;
            request.Recreate = false;

            return Ok(await promptService.Create(request));
        }
        [HttpPost]
        [Route(Routes.PromptCreateFrom)]
        public async Task<IActionResult> CreateFrom([FromBody] PromptCreateFromRequestDto request)
        {
            request.TenantId = ClaimHelper.GetTenantId(HttpContext);
            request.UserId = ClaimHelper.GetUserId(HttpContext);
            return Ok(await promptService.CreateFrom(request));
        }
        [HttpPost]
        [Route(Routes.PromptTranslate)]
        public async Task<IActionResult> Translate([FromBody] PromptTranslateDto request)
        {
            request.TenantId = ClaimHelper.GetTenantId(HttpContext);
            request.UserId = ClaimHelper.GetUserId(HttpContext);
            return Ok(await promptService.Translate(request));
        }
        [HttpPost]
        [Route(Routes.PromptMakeLonger)]
        public async Task<IActionResult> MakeLonger([FromBody] PromptLongerRequestDto request)
        {
            request.TenantId = ClaimHelper.GetTenantId(HttpContext);
            request.UserId = ClaimHelper.GetUserId(HttpContext);
            return Ok(await promptService.MakeLonger(request));
        }
        [HttpPost]
        [Route(Routes.PromptMakeShorter)]
        public async Task<IActionResult> MakeShorter([FromBody] PromptShorterRequestDto request)
        {
            request.TenantId = ClaimHelper.GetTenantId(HttpContext);
            request.UserId = ClaimHelper.GetUserId(HttpContext);
            return Ok(await promptService.MakeShorter(request));
        }
        [HttpGet]
        [Route(Routes.PromptGetOptionList)]
        public async Task<IActionResult> GetOptionList()
        {
            return Ok(await promptService.GetOptionList());
        }
    }
}
