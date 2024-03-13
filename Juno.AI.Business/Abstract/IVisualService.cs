using Juno.AI.Dto;

namespace Juno.AI.Business.Abstract
{
    public interface IVisualService
    {
        Task<string> GenerateImage(VisualGenerateRequestDto request);
    }
}
