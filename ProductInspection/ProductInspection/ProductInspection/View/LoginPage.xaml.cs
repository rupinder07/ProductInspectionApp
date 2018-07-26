using ProductInspection.View;
using ProductInspection.ViewModel;
using System;
using Xamarin.Forms;

namespace ProductInspection
{
    public partial class LoginPage : ContentPage
	{
        LoginViewModel vm = new LoginViewModel();
		public LoginPage()
		{
			InitializeComponent();
            BindingContext = vm;
		}

        public async void Login(Object sender, EventArgs args)
        {
            (sender as Button).IsEnabled = false;
            var loginDetails = await vm.Login();
            loginDetails = true;
            if (loginDetails)
            {
                await App.Repository.SaveItemAsync(new model.User() { Email = vm.Email, Password = vm.Password });
                await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
            }
            else
            {
                await DisplayAlert("Invalid Login", "Invalid Email/Password", "Ok");
            }
            (sender as Button).IsEnabled = true;
        }
    

        public void SignUp(Object sender, EventArgs args)
        {

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            HideLabel();
        }

        private void DisplayErrorMessage()
        {
            
        }

        private void HideLabel()
        {
            
        }
    }
}
