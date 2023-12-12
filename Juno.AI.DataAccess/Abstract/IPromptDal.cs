using Juno.AI.Dto;

namespace Juno.AI.DataAccess.Abstract
{
    public interface IPromptDal
    {
        Task<string> Translate(PromptTranslateDto data);
        Task<string> Send(PromptSendRequestDto data);
    }
}
