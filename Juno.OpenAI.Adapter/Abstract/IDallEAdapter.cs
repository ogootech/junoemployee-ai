using Juno.AI.Dto;

namespace Juno.OpenAI.Adapter.Abstract
{
    public interface IDallEAdapter
    {
        Task<string> GenerateImage(VisualGenerateRequestDto request);
    }
}
