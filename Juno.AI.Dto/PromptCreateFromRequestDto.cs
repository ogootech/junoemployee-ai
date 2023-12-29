using System.Text.Json.Serialization;

namespace Juno.AI.Dto
{
    public class PromptCreateFromRequestDto
    {
        [JsonIgnore]
        public Guid TenantId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        public short Language { get; set; }
        public int MaxSize { get; set; }
        public string Text { get; set; }
        public short CreateType { get; set; }
    }
}
