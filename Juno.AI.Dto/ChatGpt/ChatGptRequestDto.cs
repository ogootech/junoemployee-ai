namespace Juno.AI.Dto.ChatGpt
{
    public class ChatGptRequestDto
    {
        public ChatGptRequestDto()
        {
            Messages = new List<ChatGptMessageDto>();
        }
        public string Model { get; set; }
        public double Temperature { get; set; }
        public List<ChatGptMessageDto> Messages { get; set; }
    }
}
