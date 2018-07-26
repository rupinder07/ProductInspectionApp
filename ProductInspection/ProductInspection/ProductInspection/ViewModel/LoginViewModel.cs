using ProductInspection.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProductInspection.ViewModel
{
    public class LoginViewModel : BindableObject
    {
        private LoginService _loginService = new LoginService();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        internal async Task<bool> Login()
        {
            var response =  await _loginService.Login(Email, Password);
            return response;
        }
    }
}
