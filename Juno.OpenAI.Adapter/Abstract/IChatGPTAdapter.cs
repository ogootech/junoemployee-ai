using Juno.AI.Dto;
using Juno.AI.Dto.ChatGpt;

namespace Juno.OpenAI.Adapter.Abstract
{
    public interface IChatGPTAdapter
    {
        Task<Tuple<ChatGptCompletionResponseDto, string>> Translate(PromptTranslateDto data);
        Task<Tuple<ChatGptCompletionResponseDto, string>> MakeLonger(PromptLongerRequestDto data);
        Task<Tuple<ChatGptCompletionResponseDto, string>> MakeShorter(PromptShorterRequestDto data);
        Task<Tuple<ChatGptCompletionResponseDto, string>> Create(PromptCreateRequestDto data);
        Task<Tuple<ChatGptCompletionResponseDto, string>> CreateFrom(PromptCreateFromRequestDto data);
    }
}
