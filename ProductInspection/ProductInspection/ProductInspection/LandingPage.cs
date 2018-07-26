using ProductInspection.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProductInspection.View
{
    class LandingPage : ContentPage
    {

        public LandingPage()
        {
           
        }


        protected override async void OnAppearing()

        {

            base.OnAppearing();

            List<User> Users = await App.Repository.GetItemsAsync();
            if(Users.Count > 0)
            {
                await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
            }
            else
            {
                await Navigation.PushModalAsync(new LoginPage());
            }

        }





    }
}
