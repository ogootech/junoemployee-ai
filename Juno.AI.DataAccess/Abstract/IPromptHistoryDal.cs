using Juno.AI.Dto;

namespace Juno.AI.DataAccess.Abstract
{
    public interface IPromptHistoryDal
    {
        Task<int> InsertAndCalculate(PromptHistoryDto data);
        Task<List<PromptHistoryDto>> GetList(PromptHistoryFilterDto filter);
    }
}
