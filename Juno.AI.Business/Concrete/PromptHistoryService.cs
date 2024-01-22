using Juno.AI.Business.Abstract;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;

namespace Juno.AI.Business.Concrete
{
    public class PromptHistoryService : IPromptHistoryService
    {
        private readonly IPromptHistoryDal promptHistoryDal;
        public PromptHistoryService(IPromptHistoryDal promptHistoryDal)
        {
            this.promptHistoryDal = promptHistoryDal;
        }
        public async Task<List<PromptHistoryDto>> GetList(PromptHistoryFilterDto filter)
        {
            return await promptHistoryDal.GetList(filter);
        }
    }
}
