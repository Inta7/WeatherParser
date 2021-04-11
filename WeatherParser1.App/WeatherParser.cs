using HtmlAgilityPack;
using Nito.AsyncEx;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherParser1.App.Interfaces;
using WeatherParser1.App.Models;

namespace WeatherParser1.App
{
    public class WeatherParser : IWeatherParser
    {
        private string _htmlDocument;
        private const string _temperatureClass = "//span[contains(@class, 'weather__temp svelte-qrnlut')]";
        private const string _overcastClass = "//div[contains(@class, 'weather__description svelte-qrnlut')]";
        private const string _cityClass = "//div[contains(@class, 'weather__city svelte-qrnlut')]";
        private const string _wetClass = "//div[contains(@class, 'weather__humidity svelte-qrnlut')]";

        public WeatherParser(string htmlDocument)
        {
            _htmlDocument = htmlDocument;
        }

        public WeatherData GetForecast()
        {
            return new WeatherData
            {
                City = GetCity(),
                Overcast = GetOvercast(),
                Temperature = GetTemperature(),
                Wet = GetWet()
            };
        }

        public string GetOvercast()
        {
            var document = _htmlDocument;

            var startIndexOvercast = document.IndexOf("https://pogoda.mail.ru/prognoz/");
            var endIndexOvercast = startIndexOvercast;

            for (int i = startIndexOvercast; i < document.Length; ++i)
            {
                if (document[i] == '=' && document[i + 1] == '"')
                {
                    startIndexOvercast = i + 2;
                }

                if (document[i] == '"' && document[i + 1] == '>')
                {
                    endIndexOvercast = i;
                    break;
                }
            }
            var overcast = document.Substring(startIndexOvercast, endIndexOvercast - startIndexOvercast);

            return overcast;
        }

        public int GetTemperature()
        {
            var document = _htmlDocument;

            var startIndexTemperature = document.IndexOf("temperature quotations");
            var endIndexTemperature = startIndexTemperature;

            for (int i = startIndexTemperature; i < document.Length; ++i)
            {
                if (document[i] == '=' && document[i + 1] == '"')
                {
                    startIndexTemperature = i + 2;
                }

                if (document[i] == '"' && document[i + 1] == '>')
                {
                    endIndexTemperature = i;
                    break;
                }
            }
            var temperature = document.Substring(startIndexTemperature, endIndexTemperature - startIndexTemperature);

            return int.Parse(temperature);
        }

        public int GetWet()
        {
            return 0;
        }

        private string GetCity()
        {
            var document = _htmlDocument;

            var startIndexCity = document.IndexOf("mr.switchers.cityName");
            var endIndexCity = startIndexCity;

            for(int i = startIndexCity; i < document.Length; ++i)
            {
                if (document[i] == '=' && document[i+2] == '\'')
                {
                    startIndexCity = i+3;
                }

                if (document[i] == '\'' && document[i+1] == ';')
                {
                    endIndexCity = i;
                    break;
                }
            }

            var city = document.Substring(startIndexCity, endIndexCity-startIndexCity);

            return city;
        }
    }
}
