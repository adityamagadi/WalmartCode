using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Business.CityWeather
{
    public interface IFetchWeather
    {
        Task<Rootobject> GetWeatherReportByCity(string CityName);
    }
}
