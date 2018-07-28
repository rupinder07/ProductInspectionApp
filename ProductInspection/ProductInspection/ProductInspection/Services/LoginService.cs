using Newtonsoft.Json;
using ProductInspection.model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Services
{
    class LoginService
    {

        internal async Task<bool> Login(string email, string password)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new User() { Email = email, Password = password });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await RestClient.HttpClient.PostAsync("login", content);
                if (response.StatusCode.Equals(HttpStatusCode.Created))
                {
                    await App.Repository.SaveItemAsync(new model.User() { Email = email, Password = password });
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.Out.Write("Caught exception while logging in" + e);
                return false;
            }     
        }

        internal async static void Logout()
        {
            List<User> Users = await App.Repository.GetItemsAsync();
            if (Users.Count > 0)
            {
                await App.Repository.DeleteItemAsync(Users[0]);
            }
        }
    }
}
