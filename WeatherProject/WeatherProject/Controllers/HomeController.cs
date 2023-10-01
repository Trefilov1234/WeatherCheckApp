using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherProject.Models;
using WeatherProject.Services;

namespace WeatherProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherApiService weatherApiService;
        public HomeController(IWeatherApiService weatherApiService)
        {
            this.weatherApiService = weatherApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Search(string locationName)
        {
            WeatherApiResponse result = null;          
            try
            {
                result=await weatherApiService.SearchByLocationName(locationName);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            ViewBag.LocationName = locationName;
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}