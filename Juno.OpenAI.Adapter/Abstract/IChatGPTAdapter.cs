namespace Juno.OpenAI.Adapter.Abstract
{
    public interface IChatGPTAdapter
    {
        Task<string> Send(string prompt);
    }
}
