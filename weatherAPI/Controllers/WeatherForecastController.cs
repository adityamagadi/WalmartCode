using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using WeatherAPI.Business.CityWeather;

namespace weatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly  IFetchWeather _fetchWeather;
        public WeatherForecastController(IFetchWeather fetchWeather)
        {
            _fetchWeather = fetchWeather;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string Cities)
        {
            List<Main> mainInformation = new List<Main>();
            try
            {
                foreach (var city in Cities.Split(','))
                {
                    var response = await _fetchWeather.GetWeatherReportByCity(city);
                    mainInformation.Add(response.main);
                }

               mainInformation = mainInformation.OrderBy(x=>x.temp).ToList();

                return new JsonResult(mainInformation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
