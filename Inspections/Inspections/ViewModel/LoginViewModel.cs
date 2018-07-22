using Inspections.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Inspections.ViewModel
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
            /**
            Account account = new Account
            {
                Username = Email
            };
            account.Properties.Add("Password", Password);
            AccountStore.Create().Save(account, "ProductInspections");

            var fetchedAccount = AccountStore.Create().FindAccountsForService("ProductInspections");
            */
            return response;
            //if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            //{
            //    return "Email/Password must not be empty";
            //}
            //if (!EmailBehavior.IsValidEmail(email))
            //{
            //    return "Enter a valid email";
            //}

            //if (String.IsNullOrEmpty(error))
            //{
            //    return true;
            //}
            //ErrorMessage = error;
            //return false;
        }
    }
}
