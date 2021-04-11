using System;
using System.Collections.Generic;
using System.Text;
using WeatherParser1.App.Interfaces;
using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherParser1.App
{
    public class WeatherReceiver : IWeatherReceiver
    {
        private string _url;

        public WeatherReceiver(string url)
        {
            _url = url;
        }
        public async Task <string> GetDocument()
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage response =  await client.GetAsync(_url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var html = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(html))
                        {
                            return html;

                            
                        }

                        
                    }
                    
                }
            }
            throw new Exception("Ошибка");
        }


    }
}
