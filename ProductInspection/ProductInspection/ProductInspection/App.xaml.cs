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

        public static UserRepository repository;

        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new LandingPage());
		}

        public static UserRepository Repository
        {

            get{
                if (repository == null){
                    repository = new UserRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productinspection.db3"));
                    
                } return repository;
            }

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
