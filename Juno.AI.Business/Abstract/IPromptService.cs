using Juno.AI.Dto;

namespace Juno.AI.Business.Abstract
{
    public interface IPromptService
    {
        Task<string> Translate(PromptTranslateDto data);
        Task<string> Send(PromptSendRequestDto data);
    }
}
