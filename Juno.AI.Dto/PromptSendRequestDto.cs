namespace Juno.AI.Dto
{
    public class PromptSendRequestDto
    {
        public PromptSendRequestDto()
        {
            PromptContentTypes = new List<string>();
            PromptEnrichmentOptions = new List<string>();
            PromptTones = new List<string>();
        }
        public string Language { get; set; }
        public List<string> PromptContentTypes { get; set; }
        public List<string> PromptEnrichmentOptions { get; set; }
        public List<string> PromptTones { get; set; }
        public int MaxToken { get; set; }
        public string Prompt { get; set; }
    }
}