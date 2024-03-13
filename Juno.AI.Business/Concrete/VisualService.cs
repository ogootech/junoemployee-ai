using Juno.AI.Business.Abstract;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.Dto;

namespace Juno.AI.Business.Concrete
{
    public class VisualService : IVisualService
    {
        private readonly IVisualDal visualDal;
        public VisualService(IVisualDal visualDal)
        {
            this.visualDal = visualDal;
        }
        public async Task<string> GenerateImage(VisualGenerateRequestDto request)
        {
            return await visualDal.GenerateImage(request);
        }
    }
}
