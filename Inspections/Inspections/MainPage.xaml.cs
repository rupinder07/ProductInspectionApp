using Inspections.View;
using Inspections.ViewModel;
using System;
using Xamarin.Forms;

namespace Inspections
{
    public partial class MainPage : ContentPage
	{
        LoginViewModel vm = new LoginViewModel();
		public MainPage()
		{
			InitializeComponent();
            BindingContext = vm;
		}

        public async void Login(Object sender, EventArgs args)
        {
            (sender as Button).IsEnabled = false;
            var loginDetails = await vm.Login();

            if (loginDetails)
            {
                await Navigation.PushModalAsync(new NavigationPage(new InspectionList()));
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
            ErrorLabel.IsVisible = true;
            ErrorLabel.Text = vm.ErrorMessage;
        }

        private void HideLabel()
        {
            ErrorLabel.IsVisible = false;
        }
    }
}
