namespace Juno.AI.Business.Abstract
{
    public interface IPromptService
    {
        Task<string> Send(string prompt);
    }
}
