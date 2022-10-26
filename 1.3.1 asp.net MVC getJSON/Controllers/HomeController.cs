using GetJSON.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;




namespace GetJSON.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
       
      
        public ActionResult Weather()
        {

            return View();
        }

        

        public async Task<IActionResult> Index()
        {

           return View(new WeatherHelper());
        }

        [HttpPost]
        public ActionResult GetWeatherForecast(string InputCity)
        {
            WeatherHelper weather = new WeatherHelper();
            weather.InputCity = InputCity;
            return Json(weather.GetWeatherList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}