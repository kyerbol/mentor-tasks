using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherParameter
{
    public class WeatherParameters
    {
        public DateTimeOffset Date { get; set; }
        public int Temperature { get; set; }
        public int WindSpeed { get; set; }
    }
}
