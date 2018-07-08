using Inspections.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspections.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectionList : ContentPage
	{
		public InspectionList ()
		{
			InitializeComponent ();
            BindingContext = new InspectionListViewModel();
		}

        public void OnSelected(Object sender, EventArgs args) => Navigation.PushAsync(new NavigationPage(new ProductList()));
    }

}