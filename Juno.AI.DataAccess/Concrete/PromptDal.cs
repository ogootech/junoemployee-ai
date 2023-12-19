using Juno.AI.Common;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;
using Juno.Data.DataProvider;
using Juno.OpenAI.Adapter.Abstract;

namespace Juno.AI.DataAccess.Concrete
{
    public class PromptDal : IPromptDal
    {
        private readonly IRelationalDbProvider dataProvider;
        private readonly IChatGPTAdapter chatGPTAdapter;
        public PromptDal(IRelationalDbProvider dataProvider, IChatGPTAdapter chatGPTAdapter)
        {
            this.dataProvider = dataProvider;
            this.chatGPTAdapter = chatGPTAdapter;
        }


        public async Task<PromptResultDto> Send(PromptSendRequestDto data)
        {
            return await chatGPTAdapter.Send(data);
        }

        public async Task<PromptResultDto> Translate(PromptTranslateDto data)
        {
            return await chatGPTAdapter.Translate(data);
        }
        public async Task<List<PromptOptionDto>> GetOptionList()
        {
            return await dataProvider.GetList<PromptOptionDto>(StoredProcedureNames.PromptOptionGetList);
        }

        public async Task<PromptResultDto> MakeLonger(PromptLongerRequestDto data)
        {
            return await chatGPTAdapter.MakeLonger(data);
        }

        public async Task<PromptResultDto> MakeShorter(PromptShorterRequestDto data)
        {
            return await chatGPTAdapter.MakeShorter(data);
        }
    }
}
