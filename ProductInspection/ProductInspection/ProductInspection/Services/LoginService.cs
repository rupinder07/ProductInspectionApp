using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductInspection.Services
{
    class LoginService
    {

        internal async Task<bool> Login(string email, string password)
        {

            try
            {
                var response = await RestClient.HttpClient.GetAsync("inspection");
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }     
        }
    }
}
