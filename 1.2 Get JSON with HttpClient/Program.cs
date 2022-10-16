using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherMapParse;
using System.IO;
using System.Linq;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var WeatherParametrs = await GetWeather();

            Console.WriteLine(WeatherParametrs.cod);
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
             
            Console.WriteLine(WeatherParametrs.city.name, WeatherParametrs.city.country);
            
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
    }
}



