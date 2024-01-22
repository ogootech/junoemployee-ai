using System.Text.Json.Serialization;

namespace Juno.AI.Dto
{
    public class PromptHistoryFilterDto
    {
        [JsonIgnore]
        public Guid TenantId { get; set; }
        public Guid? UserId { get; set; }
        public int Count { get; set; }
    }
}
