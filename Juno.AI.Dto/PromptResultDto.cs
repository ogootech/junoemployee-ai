namespace Juno.AI.Dto
{
    public class PromptResultDto
    {
        public string Message { get; set; }
        public int UsageToken { get; set; }
        public int AvailableToken { get; set; }
    }
}
