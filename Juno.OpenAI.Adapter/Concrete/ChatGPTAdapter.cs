using Juno.AI.Common;
using Juno.AI.Dto;
using Juno.AI.Dto.ChatGpt;
using Juno.OpenAI.Adapter.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Juno.OpenAI.Adapter.Concrete
{
    public class ChatGPTAdapter : IChatGPTAdapter
    {
        private readonly IConfiguration configuration;
        private string apiKey;
        private string completions_url = "https://api.openai.com/v1/chat/completions";
        public ChatGPTAdapter(IConfiguration configuration)
        {
            apiKey = configuration.GetSection("OpenAiSecretKey").Value;
        }
        public async Task<string> Translate(PromptTranslateDto data)
        {
            ChatGptMessageDto message = new ChatGptMessageDto();
            message.Role = ChatGptRoles.User;

            message.Content = Messages.TranslateMessage.Replace("{Language1}", GetLanguageText(data.Language1)).Replace("{Language2}", GetLanguageText(data.Language2)).Replace("{text}", data.Text);

            ChatGptRequestDto request = new ChatGptRequestDto();
            request.Model = OpenApiModels.gpt_4_1106_preview;
            request.Temperature = 0.1;
            request.Messages.Add(message);

            var json = JsonConvert.SerializeObject(request);

            //Result
            var result = await Post(request);
            return result.Choices[0].Message.Content;
        }
        public async Task<string> Send(PromptSendRequestDto data)
        {
            ChatGptRequestDto request = new ChatGptRequestDto();
            request.Model = OpenApiModels.gpt_4_1106_preview;
            request.Temperature = CreateTemperature(data.PromptTones);

            if (data.MaxToken > 0)
            {
                //request.Max_Token = data.MaxToken;
            }

            //ContentTypes
            if (data.PromptContentTypes.Count > 0)
            {
                var list = CreatePromptContentTypes(data.PromptContentTypes);
                request.Messages.AddRange(list);
            }

            //EnrichmentOptions
            if (data.PromptEnrichmentOptions.Count > 0)
            {
                var list = CreateEnrichmentOptions(data.PromptEnrichmentOptions);
                request.Messages.AddRange(list);
            }

            //Tones
            if (data.PromptTones.Count > 0)
            {
                var list = CreateTones(data.PromptTones);
                request.Messages.AddRange(list);
            }

            //Language
            request.Messages.Add(CreateLanguage(data.Language));

            //Prompt
            request.Messages.Add(CreatePrompt(data.Prompt));

            var json = JsonConvert.SerializeObject(request);

            //Result
            var result = await Post(request);
            return result.Choices[0].Message.Content;
        }
        public async Task<string> MakeLonger(PromptLongerRequestDto data)
        {
            ChatGptRequestDto request = new ChatGptRequestDto();
            request.Model = OpenApiModels.gpt_4_1106_preview;
            //ShorterOrLonger
            request.Messages.Add(CreateShorterOrLonger(data.MaxSize));
            //Prompt
            request.Messages.Add(CreatePrompt(data.Text));
            //Result
            var result = await Post(request);
            return result.Choices[0].Message.Content;
        }
        public async Task<string> MakeShorter(PromptShorterRequestDto data)
        {
            ChatGptRequestDto request = new ChatGptRequestDto();
            request.Model = OpenApiModels.gpt_4_1106_preview;
            //ShorterOrLonger
            request.Messages.Add(CreateShorterOrLonger(data.MaxSize,true));
            //Prompt
            request.Messages.Add(CreatePrompt(data.Text));
            //Result
            var result = await Post(request);
            return result.Choices[0].Message.Content;
        }
        #region private
        private List<ChatGptMessageDto> CreatePromptContentTypes(List<short> contentTypes)
        {
            List<ChatGptMessageDto> list = new List<ChatGptMessageDto>();
            foreach (var type in contentTypes) 
            {
                ChatGptMessageDto message = new ChatGptMessageDto();
                message.Role = ChatGptRoles.System;
                switch (type)
                {
                    case PromptContentTypes.News: message.Content = PromptContentTypeTexts.News; break;
                    case PromptContentTypes.BlogPost: message.Content = PromptContentTypeTexts.BlogPost; break;
                    case PromptContentTypes.Article: message.Content = PromptContentTypeTexts.Article; break;
                    case PromptContentTypes.Declaration: message.Content = PromptContentTypeTexts.Declaration; break;
                    case PromptContentTypes.Bulletin: message.Content = PromptContentTypeTexts.Bulletin; break;
                    case PromptContentTypes.JobListing: message.Content = PromptContentTypeTexts.JobListing; break;
                }
                list.Add(message);
            }
            return list;
        }
        private List<ChatGptMessageDto> CreateEnrichmentOptions(List<short> enrichmentOptions)
        {
            List<ChatGptMessageDto> list = new List<ChatGptMessageDto>();
            foreach (var option in enrichmentOptions)
            {
                ChatGptMessageDto message = new ChatGptMessageDto();
                message.Role = ChatGptRoles.System;
                switch (option)
                {
                    case PromptEnrichmentOptions.NoEmojis: message.Content = PromptEnrichmentOptionTexts.NoEmojis; break;
                    case PromptEnrichmentOptions.UseEmojisInAllFields: message.Content = PromptEnrichmentOptionTexts.UseEmojisInAllFields; break;
                    case PromptEnrichmentOptions.UseEmojisOnlyInContent: message.Content = PromptEnrichmentOptionTexts.UseEmojisOnlyInContent; break;
                    case PromptEnrichmentOptions.UseEmojisOnlyInTitle: message.Content = PromptEnrichmentOptionTexts.UseEmojisOnlyInTitle; break;
                }
                list.Add(message);
            }
            return list;
        }
        private List<ChatGptMessageDto> CreateTones(List<short> tones)
        {
            List<ChatGptMessageDto> list = new List<ChatGptMessageDto>();
            foreach (var tone in tones)
            {
                ChatGptMessageDto message = new ChatGptMessageDto();
                message.Role = ChatGptRoles.System;
                switch (tone)
                {
                    case PromptTones.Offical: message.Content = PromptToneTexts.Offical; break;
                    case PromptTones.Casual: message.Content = PromptToneTexts.Casual; break;
                    case PromptTones.Professional: message.Content = PromptToneTexts.Professional; break;
                    case PromptTones.Enthusiastic: message.Content = PromptToneTexts.Enthusiastic; break;
                    case PromptTones.Informative: message.Content = PromptToneTexts.Informative; break;
                    case PromptTones.Witty: message.Content = PromptToneTexts.Witty; break;
                }
                list.Add(message);
            }
            return list;
        }
        private double CreateTemperature(List<short> tones)
        { 
            double temperature = 0.5;
            foreach (var tone in tones)
            {
                switch (tone)
                {
                    case PromptTones.Offical: temperature = 0.2; break;
                    case PromptTones.Casual: temperature = 0.5; break;
                    case PromptTones.Professional: temperature = 0.3; break;
                    case PromptTones.Enthusiastic: temperature = 0.6; break;
                    case PromptTones.Informative: temperature = 0.4; break;
                    case PromptTones.Witty: temperature = 0.8; break;
                }
            }
            return temperature;
        }
        private string GetLanguageText(short language)
        {
            string lang = string.Empty;
            switch (language)
            {
                case 1: lang = Languages.Turkish; break;
                case 2: lang = Languages.English; break;
                default: lang = Languages.Turkish; break;
            }
            return lang;
        }
        private ChatGptMessageDto CreateLanguage(short language)
        {
            ChatGptMessageDto message = new ChatGptMessageDto();
            message.Role = ChatGptRoles.System;

            string lang = string.Empty;
            switch (language)
            {
                case 1: lang = Languages.Turkish; break;
                case 2: lang = Languages.English; break;
                default: lang = Languages.Turkish; break;
            }

            message.Content = "Create all '" + GetLanguageText(language) + "'";
            return message;
        }
        private ChatGptMessageDto CreatePrompt(string prompt)
        {
            ChatGptMessageDto message = new ChatGptMessageDto();
            message.Role = ChatGptRoles.User;
            message.Content = prompt;
            return message;
        }
        private ChatGptMessageDto CreateShorterOrLonger(int maxSize, bool isShort = false)
        {
            ChatGptMessageDto message = new ChatGptMessageDto();
            message.Role = ChatGptRoles.System;

            string text = isShort ? "shorter" : "longer";

            message.Content = "Create '" + text + "' and max character size have to be " + maxSize;
            return message;
        }
        private async Task<ChatGptCompletionResponseDto> Post(ChatGptRequestDto request)
        {
            ChatGptCompletionResponseDto result = new ChatGptCompletionResponseDto();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var response = await httpClient.PostAsJsonAsync(completions_url, request);
            //response.EnsureSuccessStatusCode();
            var resultAsString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<ChatGptCompletionResponseDto>(resultAsString);
                if (result != null)
                {
                    if (result.Choices[0].Finish_Reason == ChatGptFinishReasons.Stop)
                    {
                        return result;
                    }
                }

            }
            else
            {
                throw new Exception(resultAsString);
            }

            return result;
        }
        #endregion
        
    }
}
