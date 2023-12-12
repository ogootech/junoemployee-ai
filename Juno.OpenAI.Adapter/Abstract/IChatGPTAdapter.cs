using Juno.AI.Dto;

namespace Juno.OpenAI.Adapter.Abstract
{
    public interface IChatGPTAdapter
    {
        Task<string> Translate(PromptTranslateDto data);
        Task<string> Send(PromptSendRequestDto data);
    }
}
