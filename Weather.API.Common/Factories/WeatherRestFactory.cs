using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.API.Common.Factories
{
    public class WeatherRestFactory : IWeatherRestFactory
    {
        private RestClient client = null;
        private RestRequest request = null;

        public WeatherRestFactory()
        {
            client = new RestClient("https://openweathermap.org/data/2.5/weather");
        }

        public (RestRequest, RestClient) ReturnHttpClient(Method Method, Dictionary<string, string> QueryParams, string EndPoint)
        {
            request = new RestRequest(EndPoint, Method);

            switch (Method)
            {
                case Method.GET:
                    if (QueryParams != null)
                    {
                        foreach (var param in QueryParams)
                        {
                            request.AddQueryParameter(param.Key, param.Value);
                        }
                    }
                    break;
            }

            return (request, client);
        }
    }
}
