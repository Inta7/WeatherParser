using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherParser1.App.Models;

namespace WeatherParser1.App.Interfaces
{
    public interface IWeatherParser
    {
        WeatherData GetForecast();

        int GetTemperature();

        string GetOvercast();

        int GetWet();
    }
}
