using Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Weather.API.Common.Factories;

namespace WeatherAPI.Business.CityWeather
{
    public class FetchWeather : IFetchWeather
    {
        private readonly IWeatherRestFactory _weatherRestFactory;
        private const string appID = "439d4b804bc8187953eb36d2a8c26a02";
        private const string weatherEndPoint = "https://openweathermap.org/data/2.5/weather";
        public FetchWeather(IWeatherRestFactory weatherRestFactory)
        {
            _weatherRestFactory = weatherRestFactory;
        }

        public async Task<Rootobject> GetWeatherReportByCity(string CityName)
        {
            var headers = new Dictionary<string, string> { { "q", CityName } , { "appid", appID} };
            var RestObject = _weatherRestFactory.ReturnHttpClient(Method.GET, headers, weatherEndPoint);
            //thread 1 --> thread pool

            var response = await RestObject.Item2.ExecuteAsync(RestObject.Item1).ConfigureAwait(false);
            // thread n
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var CastedResponse = JsonConvert.DeserializeObject<Rootobject>(response.Content);
                return CastedResponse;
            }

            return null;
        }
    }
}
