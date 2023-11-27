using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;
using Juno.OpenAI.Adapter.Abstract;

namespace Juno.AI.DataAccess.Concrete
{
    public class VisualDal : IVisualDal
    {
        private readonly IDallEAdapter dallEAdapter;
        public VisualDal(IDallEAdapter dallEAdapter)
        {
            this.dallEAdapter = dallEAdapter;
        }
        public async Task<string> GenerateImage(VisualGenerateRequestDto request)
        {
            return await dallEAdapter.GenerateImage(request);
        }
    }
}
