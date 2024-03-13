using Juno.AI.Dto;

namespace Juno.AI.DataAccess.Abstract
{
    public interface IVisualDal
    {
        Task<string> GenerateImage(VisualGenerateRequestDto request);
    }
}
