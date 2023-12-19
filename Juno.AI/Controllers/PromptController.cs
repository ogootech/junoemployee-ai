﻿using Juno.AI.Business.Abstract;
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
            return Ok(await promptService.Send(request));
        }
        [HttpPost]
        [Route(Routes.PromptTranslate)]
        public async Task<IActionResult> Translate([FromBody] PromptTranslateDto request)
        {
            return Ok(await promptService.Translate(request));
        }
        [HttpPost]
        [Route(Routes.PromptMakeLonger)]
        public async Task<IActionResult> MakeLonger([FromBody] PromptLongerRequestDto request)
        {
            return Ok(await promptService.MakeLonger(request));
        }
        [HttpPost]
        [Route(Routes.PromptMakeShorter)]
        public async Task<IActionResult> MakeShorter([FromBody] PromptShorterRequestDto request)
        {
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
