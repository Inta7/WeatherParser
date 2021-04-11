using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherParser1.App.Models;

namespace WeatherParser1.App.Interfaces
{
    public interface IWeatherProvider
    {
        Task<WeatherData> GetForecast();
    }
}
