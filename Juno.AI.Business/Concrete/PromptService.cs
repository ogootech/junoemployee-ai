using Juno.AI.Business.Abstract;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;

namespace Juno.AI.Business.Concrete
{
    public class PromptService : IPromptService
    {
        private readonly IPromptDal promptDal;
        public PromptService(IPromptDal promptDal)
        {
            this.promptDal = promptDal;
        }

        public async Task<string> Send(PromptSendRequestDto data)
        {
            return await promptDal.Send(data);
        }

        public async Task<string> Translate(PromptTranslateDto data)
        {
            return await promptDal.Translate(data);
        }

        public async Task<List<PromptOptionDto>> GetOptionList()
        {
            return await promptDal.GetOptionList();
        }

        public async Task<string> MakeLonger(PromptLongerRequestDto data)
        {
            return await promptDal.MakeLonger(data);
        }

        public async Task<string> MakeShorter(PromptShorterRequestDto data)
        {
            return await promptDal.MakeShorter(data);
        }
    }
}
