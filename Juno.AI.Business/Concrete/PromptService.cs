using Juno.AI.Business.Abstract;
using Juno.AI.DataAccess.Abstract;

namespace Juno.AI.Business.Concrete
{
    public class PromptService : IPromptService
    {
        private readonly IPromptDal promptDal;
        public PromptService(IPromptDal promptDal)
        {
            this.promptDal = promptDal;
        }
        public async Task<string> Send(string prompt)
        {
            return await promptDal.Send(prompt);
        }
    }
}
