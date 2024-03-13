using System.Text.Json.Serialization;

namespace Juno.AI.Dto
{
    public class PromptCreateRequestDto
    {
        public PromptCreateRequestDto()
        {
            PromptCreateTypes = new List<short>();
            PromptContentTypes = new List<short>();
            PromptEnrichmentOptions = new List<short>();
            PromptTones = new List<short>();
        }
        [JsonIgnore]
        public Guid TenantId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        public short Language { get; set; }
        public List<short> PromptCreateTypes { get; set; }
        public List<short> PromptContentTypes { get; set; }
        public List<short> PromptEnrichmentOptions { get; set; }
        public List<short> PromptTones { get; set; }
        public int MaxToken { get; set; }
        public string Prompt { get; set; }
        public int TitleSize { get; set; }
        public int DescriptionSize { get; set; }
        public int ContentSize { get; set; }
        public bool Recreate { get; set; }
    }
}