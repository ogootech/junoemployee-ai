using Juno.AI.Common;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;
using Juno.Data.DataProvider;
using Juno.OpenAI.Adapter.Abstract;

namespace Juno.AI.DataAccess.Concrete
{
    public class PromptModeDal : IPromptModeDal
    {
        private readonly IRelationalDbProvider dataProvider;

        public PromptModeDal(IRelationalDbProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public async Task<List<PromptModeDto>> GetList()
        {
            return await dataProvider.GetList<PromptModeDto>(StoredProcedureNames.PromptModeGetList);
        }
    }
}
