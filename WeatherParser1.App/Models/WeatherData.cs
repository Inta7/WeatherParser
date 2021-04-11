using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherParser1.App.Models
{
    public class WeatherData
    {
        public string City { get; set; }

        public int Temperature { get; set; }

        public string Overcast { get; set; }

        public int Wet { get; set; }
    }
}
