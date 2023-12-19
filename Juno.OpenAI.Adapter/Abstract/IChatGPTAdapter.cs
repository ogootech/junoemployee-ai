using Juno.AI.Dto;

namespace Juno.OpenAI.Adapter.Abstract
{
    public interface IChatGPTAdapter
    {
        Task<PromptResultDto> Translate(PromptTranslateDto data);
        Task<PromptResultDto> MakeLonger(PromptLongerRequestDto data);
        Task<PromptResultDto> MakeShorter(PromptShorterRequestDto data);
        Task<PromptResultDto> Send(PromptSendRequestDto data);
    }
}
