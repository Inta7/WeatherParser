using System;
using WeatherParser1.App;
using WeatherParser1.App.Models;
using WeatherParser1.App.Interfaces;
using System.Threading.Tasks;

namespace WeatherParser1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IWeatherProvider weatherProvider = new WeatherProvider();

            var forecast = await weatherProvider.GetForecast();

            Console.WriteLine($"Погода сегодня в городе {forecast.City}");
            Console.WriteLine($"Температура {(forecast.Temperature > 0? "+":"")}{forecast.Temperature}");
            Console.WriteLine($"Облачность {forecast.Overcast}");
            Console.ReadLine();
        }
    }
}
