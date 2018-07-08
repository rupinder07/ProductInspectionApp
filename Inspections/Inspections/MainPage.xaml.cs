using Inspections.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Inspections
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        public void Login(Object sender, EventArgs args) => Navigation.PushModalAsync(new NavigationPage(new InspectionList()));

        public void SignUp(Object sender, EventArgs args)
        {

        }
    }
}
