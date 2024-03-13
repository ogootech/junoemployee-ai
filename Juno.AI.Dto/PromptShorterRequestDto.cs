using System.Text.Json.Serialization;

namespace Juno.AI.Dto
{
    public class PromptShorterRequestDto
    {
        [JsonIgnore]
        public Guid TenantId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        public int MaxSize { get; set; }
        public string Text { get; set; }
    }
}
