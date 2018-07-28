using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductInspection.Services
{
    class RestClient
    {
        public static HttpClient HttpClient { get; } = new HttpClient()
        {
            BaseAddress = new Uri("http://10.34.27.15:8080/"),
            Timeout = TimeSpan.FromSeconds(5)
        };
    }
}
