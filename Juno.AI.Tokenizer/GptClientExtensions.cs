namespace Juno.AI.Tokenizer
{
    public static class GptClientExtensions
    {
        public static async Task<int> EstimateTokenCountAsync(IEnumerable<(string role, string content)> entries)
        {
            var tokenizer = await GptTokenizer.GetGpt3TokenizerAsync();

            var num_tokens = 0;

            foreach (var (role, content) in entries)
            {
                num_tokens += 4;
                num_tokens += tokenizer.GetTokens(role).Length;
                num_tokens += tokenizer.GetTokens(content).Length;
                num_tokens += 1;
            }

            num_tokens += 2;

            return num_tokens;
        }


    }
}
