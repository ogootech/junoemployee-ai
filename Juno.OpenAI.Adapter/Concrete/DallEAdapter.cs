using Juno.AI.Dto;
using Juno.OpenAI.Adapter.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Juno.OpenAI.Adapter.Concrete
{
    public class DallEAdapter : IDallEAdapter
    {
        private readonly IConfiguration configuration;
        private string apiKey;
        public DallEAdapter(IConfiguration configuration)
        {
            apiKey = configuration.GetSection("OpenAiSecretKey").Value;
        }
        public async Task<string> GenerateImage(VisualGenerateRequestDto visualGenerateRequest)
        {
            string result = string.Empty; 
            try
            {
                string url = "https://api.openai.com/v1/images/generations";
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(visualGenerateRequest));

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + apiKey);

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {

                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseString = streamReader.ReadToEnd();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var responseJson = JsonConvert.DeserializeObject<DallEResponseDto>(responseString);
                            result = responseJson.Data[0].Url;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse errorResponse)
                {
                    using (var errorStreamReader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        var errorResponseString = errorStreamReader.ReadToEnd();
                    }
                }
                throw ex;
            }
            return result;
        }
    }
}
