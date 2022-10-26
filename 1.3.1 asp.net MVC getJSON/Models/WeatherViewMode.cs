using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

namespace GetJSON.Models    
{
    public class WeatherHelper
    {
        private static readonly HttpClient client = new HttpClient();

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        [Display(Name = "Enter the name of the city")]
        //Свойство для хранения данных о введенном городе.
        public string InputCity { get; set; }

        //AppId выданный OpenWeatherApi.
        private static string appId = "ec9a70d26efefb2f50b06809908b582d";

        /// <summary>
        /// Метод для получения данных с openweatherapi в формате json и отправки ответа на основе сформированной Url с названием города, и AppId.
        /// </summary>
        /// <returns>Object</returns>
        public async Task<RootObject> GetWeatherList()
        {
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Chrome");

            string appId = "c01731d6b51bc49477ef31e86290b79c";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", InputCity, appId);

            var streamTask = client.GetStreamAsync(url);
            var response = await JsonSerializer.DeserializeAsync<RootObject>(await streamTask);

            return response;
        }
    }

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class Rain
    {
        public double __invalid_name__3h { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootObject
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }
}