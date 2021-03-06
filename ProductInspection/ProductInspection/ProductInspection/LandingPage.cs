﻿using ProductInspection.Model;
using ProductInspection.repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProductInspection.View
{
    class LandingPage : ContentPage
    {
        private BaseRepository<User> UserRepository = new BaseRepository<User>();

        public LandingPage()
        {
           
        }

        protected override async void OnAppearing()

        {
            base.OnAppearing();

            /*
             * Using repository to store username and password. Tried with Xamarin.Auth but was facing issues with versions of Android libraries
             * So in interest of time, using repository
             */
            List<User> Users = await UserRepository.GetItemsAsync();
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
