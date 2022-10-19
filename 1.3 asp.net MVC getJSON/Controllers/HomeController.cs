using GetJSON.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Net.Http.Headers;

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

        private static async Task<WeatherMapResponse> GetWeather()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Chrome");
            var streamTask = client.GetStreamAsync("https://api.openweathermap.org/data/2.5/forecast?lat=44.34&lon=10.99&appid=c01731d6b51bc49477ef31e86290b79c");
            var WeatherParametrs = await JsonSerializer.DeserializeAsync<WeatherMapResponse>(await streamTask);

            return WeatherParametrs;
        }
      
        public ActionResult Weather()
        {

            return View();
        }

        public async Task<IActionResult> Index()
        {


            var WeatherParametrs = await GetWeather();

          //  var dr = WeatherParametrs.cod;
           /* Console.WriteLine(WeatherParametrs.cod);
            Console.WriteLine(WeatherParametrs.message);
            Console.WriteLine(WeatherParametrs.cnt);

            foreach (var item in WeatherParametrs.lists)
            {
                Console.WriteLine(item.dt);

                foreach (var itemWeaher in item.weather)
                {
                    Console.WriteLine(itemWeaher.Main);
                    Console.WriteLine(itemWeaher.Description);
                }

                Console.WriteLine(item.Main.temp);
                Console.WriteLine(item.Main.temp_min);
                Console.WriteLine(item.Main.temp_max);
            }

            Console.WriteLine(WeatherParametrs.city.name, WeatherParametrs.city.country);*/

            return View(WeatherParametrs);
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