using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;
using Juno.OpenAI.Adapter.Abstract;

namespace Juno.AI.DataAccess.Concrete
{
    public class PromptDal : IPromptDal
    {
        private readonly IChatGPTAdapter chatGPTAdapter;
        public PromptDal(IChatGPTAdapter chatGPTAdapter)
        {
            this.chatGPTAdapter = chatGPTAdapter;
        }
        public async Task<string> Send(PromptSendRequestDto data)
        {
            return await chatGPTAdapter.Send(data);
        }

        public async Task<string> Translate(PromptTranslateDto data)
        {
            return await chatGPTAdapter.Translate(data);
        }
    }
}
