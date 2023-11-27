using Juno.AI.Business.Abstract;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;

namespace Juno.AI.Business.Concrete
{
    public class PromptModeService : IPromptModeService
    {
        private readonly IPromptModeDal promptModeDal;

        public PromptModeService(IPromptModeDal promptModeDal)
        {
            this.promptModeDal = promptModeDal;
        }

        public async Task<List<PromptModeDto>> GetList()
        {
            return await promptModeDal.GetList();
        }
    }
}
