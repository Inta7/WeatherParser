using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherParser1.App.Interfaces;
using WeatherParser1.App.Models;

namespace WeatherParser1.App
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly AsyncLazy<IWeatherParser> _weatherParser;
        private readonly IWeatherReceiver _weatherReceiver;
        private const string url = "https://www.mail.ru";

        public WeatherProvider()
        {
            _weatherReceiver = new WeatherReceiver(url);
            _weatherParser = new AsyncLazy<IWeatherParser>(async () => new WeatherParser(await _weatherReceiver.GetDocument()));
        }

        public async Task<WeatherData> GetForecast()
        {
            var parser = await _weatherParser;
            return parser.GetForecast();
        }
    }
}
