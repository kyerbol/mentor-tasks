using System;
using System.Text.Json;
using System.Collections;
using WeatherParameter;
using System.IO;


namespace DeserializeFromFileAsync
{


    public class Program
    {
        public static async Task Main()
        {
            // 1-option with using System.Text.Json;

            string fileName = "WeatherParameters.json";
            using FileStream openStream = File.OpenRead(fileName);

            await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<WeatherParameters>(openStream))
            {
                Console.WriteLine($"{item?.Date:M} - {item?.Temperature} deg - {item?.WindSpeed} km/h");
            }

            // 2-option with using Newtonsoft.Json;
            /*
            string json = System.IO.File.ReadAllText("WeatherParameters.json");
            var people = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeatherParameters>>(json);
            if (people is not null)
                foreach (var item in people)
            {
                Console.WriteLine($"{item?.Date:M} - {item?.Temperature} deg - {item?.WindSpeed} km/h");
            }
            */

        }

    }
}



