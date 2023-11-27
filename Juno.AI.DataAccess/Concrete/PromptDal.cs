using Juno.AI.DataAccess.Abstract;
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
        public async Task<string> Send(string prompt)
        {
            return await chatGPTAdapter.Send(prompt);
        }
    }
}
