using ProductInspection.repository;
using ProductInspection.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ProductInspection
{
	public partial class App : Application
	{

        public App ()
		{
			InitializeComponent();

            //Initialize a connection which will be used to access the database throughout application
            Console.Out.Write("Path of DB: " + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            RepositoryHelper.InitializeConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "productinspection4.db3"));

            //Redirecting the app to a facade
            //This facade decides whether to redirect user to login page or to home page
			MainPage = new NavigationPage(new LandingPage());
		}

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
