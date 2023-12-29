namespace Juno.AI.Dto
{
    public class PromptHistoryDto
    {
        public Guid TenantId { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int CompletionToken { get; set; }
        public int PromptToken { get; set; }
        public int TotalToken { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
