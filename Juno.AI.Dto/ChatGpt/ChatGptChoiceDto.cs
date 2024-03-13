namespace Juno.AI.Dto.ChatGpt
{
    public class ChatGptChoiceDto
    {
        public ChatGptChoiceDto()
        {
            Message = new ChatGptMessageDto();
        }
        public string Finish_Reason { get; set; }
        public int Index { get; set; }
        public ChatGptMessageDto Message { get; set; }
    }
}
