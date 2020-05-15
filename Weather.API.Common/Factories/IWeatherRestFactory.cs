using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.API.Common.Factories
{
    public interface IWeatherRestFactory
    {
        (RestRequest, RestClient) ReturnHttpClient(Method Method, Dictionary<string, string> QueryParams, string EndPoint);
    }
}
