using Juno.AI.Common;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;
using Juno.AI.Dto.ChatGpt;
using Juno.Data.DataProvider;
using Juno.OpenAI.Adapter.Abstract;
using Newtonsoft.Json;

namespace Juno.AI.DataAccess.Concrete
{
    public class PromptDal : IPromptDal
    {
        private readonly IRelationalDbProvider dataProvider;
        private readonly IChatGPTAdapter chatGPTAdapter;
        private readonly IPromptHistoryDal promptHistoryDal;
        public PromptDal(IRelationalDbProvider dataProvider, IChatGPTAdapter chatGPTAdapter, IPromptHistoryDal promptHistoryDal)
        {
            this.dataProvider = dataProvider;
            this.chatGPTAdapter = chatGPTAdapter;
            this.promptHistoryDal = promptHistoryDal;
        }


        public async Task<List<PromptOptionDto>> GetOptionList()
        {
            return await dataProvider.GetList<PromptOptionDto>(StoredProcedureNames.PromptOptionGetList);
        }
        public async Task<PromptResultDto> Create(PromptCreateRequestDto data)
        {
            var result = await chatGPTAdapter.Create(data);
            return await InsertHistoryAndSetResult(result, data.TenantId, data.UserId, JsonConvert.SerializeObject(data));
        }
        public async Task<PromptResultDto> CreateFrom(PromptCreateFromRequestDto data)
        {
            var result = await chatGPTAdapter.CreateFrom(data);
            return await InsertHistoryAndSetResult(result, data.TenantId, data.UserId, JsonConvert.SerializeObject(data));
        }
        public async Task<PromptResultDto> Translate(PromptTranslateDto data)
        {
            var result = await chatGPTAdapter.Translate(data);
            return await InsertHistoryAndSetResult(result, data.TenantId, data.UserId, JsonConvert.SerializeObject(data));
        }

        public async Task<PromptResultDto> MakeLonger(PromptLongerRequestDto data)
        {
            var result = await chatGPTAdapter.MakeLonger(data);
            return await InsertHistoryAndSetResult(result, data.TenantId, data.UserId, JsonConvert.SerializeObject(data));
        }

        public async Task<PromptResultDto> MakeShorter(PromptShorterRequestDto data)
        {
            var result = await chatGPTAdapter.MakeShorter(data);
            return await InsertHistoryAndSetResult(result, data.TenantId, data.UserId, JsonConvert.SerializeObject(data));
        }

        private async Task<PromptResultDto> InsertHistoryAndSetResult(ChatGptCompletionResponseDto result, Guid tenantId, Guid userId, string request)
        {
            int availableToken = await promptHistoryDal.InsertAndCalculate(new PromptHistoryDto() 
            {
                TenantId = tenantId,
                CreatedBy = userId,
                CreatedDate = DateTime.UtcNow,
                Request = request,
                Response = JsonConvert.SerializeObject(result),
                CompletionToken = result.Usage.Completion_Tokens,
                PromptToken = result.Usage.Prompt_Tokens,
                TotalToken = result.Usage.Total_Tokens

            });
            return new PromptResultDto() { UsageToken = result.Usage.Completion_Tokens, Message = result.Choices[0].Message.Content, AvailableToken = availableToken };
        }
    }
}
