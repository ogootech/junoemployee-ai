using System.Text.Json.Serialization;

namespace Juno.AI.Dto
{
    public class PromptTranslateDto
    {
        [JsonIgnore]
        public Guid TenantId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        public short Language1 { get; set; }
        public short Language2 { get; set; }
        public string Text { get; set; }
    }
}
