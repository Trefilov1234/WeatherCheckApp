using WeatherProject.Models;

namespace WeatherProject.Services
{
    public interface IWeatherApiService
    {
        Task<WeatherApiResponse> SearchByLocationName(string locationName);
    }
}