using Juno.AI.Dto;

namespace Juno.AI.Business.Abstract
{
    public interface IPromptModeService
    {
        Task<List<PromptModeDto>> GetList();
    }
}
