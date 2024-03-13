namespace Juno.AI.Dto.ChatGpt
{
    public class ChatGptUsageDto
    {
        public int Completion_Tokens { get; set; }
        public int Prompt_Tokens { get; set; }
        public int Total_Tokens { get; set; }
    }
}
