using System.Net.Http;

namespace Inspections.Services
{
    class RestClient
    {

        private const string BACKEND_URL = "http://localhost:8080/";
        public HttpClient HttpClient { get; } = new HttpClient();

    }
}
