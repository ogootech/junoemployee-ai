using Juno.AI.Common;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;
using Juno.Data.DataProvider;
using Juno.OpenAI.Adapter.Abstract;

namespace Juno.AI.DataAccess.Concrete
{
    public class PromptHistoryDal : IPromptHistoryDal
    {
        private readonly IRelationalDbProvider dataProvider;
        private readonly IChatGPTAdapter chatGPTAdapter;
        public PromptHistoryDal(IRelationalDbProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public async Task<int> InsertAndCalculate(PromptHistoryDto data)
        {
            return await dataProvider.Insert<int>(StoredProcedureNames.PromptHıstoryCreateAndCalculateAvailableToken, data);
        }
    }
}
