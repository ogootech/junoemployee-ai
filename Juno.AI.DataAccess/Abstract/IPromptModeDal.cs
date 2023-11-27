using Juno.AI.Dto;

namespace Juno.AI.DataAccess.Abstract
{
    public interface IPromptModeDal
    {
        Task<List<PromptModeDto>> GetList();
    }
}
