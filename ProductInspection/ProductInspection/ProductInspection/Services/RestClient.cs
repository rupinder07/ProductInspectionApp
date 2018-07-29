using Newtonsoft.Json;
using ProductInspection.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Services
{
    class RestClient
    {
        public static string HOSTNAME = "172.20.10.2";
        public static int port = 8080;
        public static int TIMEOUT_MILLIS = 3000;

        public static HttpClient HttpClient { get; } = new HttpClient()
        {
            BaseAddress = new Uri("http://" + HOSTNAME + ":" + port +"/"),
            Timeout = TimeSpan.FromMilliseconds(TIMEOUT_MILLIS)
        };

        public async static Task<HttpResponseMessage> PerformOperation(Event queuedEvent)
        {
            if(queuedEvent.Operation == HttpOperation.UPDATE)
            {
                var Json = JsonConvert.SerializeObject(queuedEvent.Entity);
                var content = new StringContent(Json, Encoding.UTF8, "application/json");
                await RestClient.HttpClient.PutAsync(queuedEvent.URI, content);
            }

            return new HttpResponseMessage();
        }
    }
}
