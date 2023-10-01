using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherProject.Models;
using WeatherProject.Options;

namespace WeatherProject.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private HttpClient httpClient;
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public WeatherApiService(IHttpClientFactory httpClientFactory,IOptions<WeatherApiOptions> options)
        {
            BaseUrl = options.Value.BaseUrl;
            ApiKey = options.Value.ApiKey;
            httpClient= httpClientFactory.CreateClient();
        }
        public async Task<WeatherApiResponse> SearchByLocationName(string locationName)
        {
            var response = await httpClient.GetAsync($"{BaseUrl}?q={locationName}&appid={ApiKey}&units=metric");
            var json=await response.Content.ReadAsStringAsync();
            var result= JsonConvert.DeserializeObject<WeatherApiResponse>(json);
            if(result.message!=null)
            {
                throw new Exception(result.message);
            }
            return result;
        }
    }
}
