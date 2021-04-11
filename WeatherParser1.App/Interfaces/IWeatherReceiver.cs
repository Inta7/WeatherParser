using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherParser1.App.Interfaces
{
    public interface IWeatherReceiver
    {
        Task <string> GetDocument();
    }
}
