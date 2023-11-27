using Juno.AI.Common;
using Juno.OpenAI.Adapter.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Juno.OpenAI.Adapter.Concrete
{
    public class ChatGPTAdapter : IChatGPTAdapter
    {
        private readonly IConfiguration configuration;
        private string apiKey;
        public ChatGPTAdapter(IConfiguration configuration)
        {
            apiKey = configuration.GetSection("OpenAiSecretKey").Value;
        }
        public async Task<string> Send(string prompt)
        {
            var requestBody = new
            {
                prompt = prompt,
                model = OpenApiModels.gpt3_5_turbo_instruct,
                max_tokens = 150,
                temperature = 0.5
            };

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await httpClient.PostAsJsonAsync("completions", requestBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
