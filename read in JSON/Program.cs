using System;
using System.Text.Json;

namespace DeserializeFromFileAsync
{
    public class WeatherParameters
    {
        public DateTimeOffset Date { get; set; }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
    }

    public class Program
    {
        public static async Task Main()
        {
            string fileName = "WeatherParameters.json";
            using FileStream openStream = File.OpenRead(fileName);
            WeatherParameters? WeatherParameters =
                await JsonSerializer.DeserializeAsync<WeatherParameters>(openStream);

            Console.WriteLine($"{WeatherParameters?.Date:M} - {WeatherParameters?.Temperature} deg - {WeatherParameters?.WindSpeed} km/h");
        }
    }
}