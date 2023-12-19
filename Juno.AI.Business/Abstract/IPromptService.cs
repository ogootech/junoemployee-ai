using Juno.AI.Dto;

namespace Juno.AI.Business.Abstract
{
    public interface IPromptService
    {
        Task<string> Send(PromptSendRequestDto data);
        Task<string> Translate(PromptTranslateDto data);
        Task<string> MakeLonger(PromptLongerRequestDto data);
        Task<string> MakeShorter(PromptShorterRequestDto data);
        Task<List<PromptOptionDto>> GetOptionList();
    }
}
