namespace Juno.AI.Dto.ChatGpt
{
    public class ChatGptCompletionResponseDto
    {
        public ChatGptCompletionResponseDto()
        {
            Choices = new List<ChatGptChoiceDto>();
            Usage = new ChatGptUsageDto();
        }
        public string Id { get; set; }
        public string Model { get; set; }
        public string Object { get; set; }
        public List<ChatGptChoiceDto> Choices { get; set; }
        public ChatGptUsageDto Usage { get; set; }
    }
}
