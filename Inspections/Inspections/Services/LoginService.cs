using System.Net.Http;
using System.Threading.Tasks;

namespace Inspections.Services
{
    class LoginService
    {

        private const string BACKEND_URL = "http://172.20.10.3:8080/inspection";
        public HttpClient _client = new HttpClient();

        internal async Task<bool> Login(string email, string password)
        {
            var response = await _client.GetAsync(BACKEND_URL);
            return response.IsSuccessStatusCode;
        }
    }
}
