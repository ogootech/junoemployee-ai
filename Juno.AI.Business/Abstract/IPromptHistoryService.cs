using Juno.AI.Dto;

namespace Juno.AI.Business.Abstract
{
    public interface IPromptHistoryService
    {
        Task<List<PromptHistoryDto>> GetList(PromptHistoryFilterDto filter);
    }
}
