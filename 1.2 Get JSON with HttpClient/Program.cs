//using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherMapParse;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var WeatherParametrs = await GetWeather();

            foreach (var repo in WeatherParametrs)
            {
                Console.WriteLine(repo.cod);
                // Console.WriteLine(repo.message);
                /*   Console.WriteLine(repo.cnt);
                   */
            }
        }

        private static async Task<List<WeatherMapResponse>> GetWeather()
        {
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
             client.DefaultRequestHeaders.Add("User-Agent", "Csharp");
            HttpClient httpclient = new HttpClient();
            var streamTask = client.GetStreamAsync("https://api.openweathermap.org/data/2.5/forecast?lat=44.34&lon=10.99&appid=c01731d6b51bc49477ef31e86290b79c");
            var WeatherParametrs = await JsonSerializer.DeserializeAsync<List<WeatherMapResponse>>(await streamTask);
                       
            return WeatherParametrs;
        }
    }
}