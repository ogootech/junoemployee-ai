﻿using Juno.AI.Dto;

namespace Juno.AI.Business.Abstract
{
    public interface IPromptService
    {
        Task<PromptResultDto> Create(PromptCreateRequestDto data);
        Task<PromptResultDto> CreateFrom(PromptCreateFromRequestDto data);
        Task<PromptResultDto> Translate(PromptTranslateDto data);
        Task<PromptResultDto> MakeLonger(PromptLongerRequestDto data);
        Task<PromptResultDto> MakeShorter(PromptShorterRequestDto data);
        Task<List<PromptOptionDto>> GetOptionList();
    }
}
