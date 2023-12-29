using Juno.AI.Dto;
using Juno.AI.Dto.ChatGpt;

namespace Juno.OpenAI.Adapter.Abstract
{
    public interface IChatGPTAdapter
    {
        Task<ChatGptCompletionResponseDto> Translate(PromptTranslateDto data);
        Task<ChatGptCompletionResponseDto> MakeLonger(PromptLongerRequestDto data);
        Task<ChatGptCompletionResponseDto> MakeShorter(PromptShorterRequestDto data);
        Task<ChatGptCompletionResponseDto> Create(PromptCreateRequestDto data);
        Task<ChatGptCompletionResponseDto> CreateFrom(PromptCreateFromRequestDto data);
    }
}
