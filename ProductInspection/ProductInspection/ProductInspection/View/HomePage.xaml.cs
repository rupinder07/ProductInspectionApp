using ProductInspection.Model;
using ProductInspection.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductInspection.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private InspectionListViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = new InspectionListViewModel();
        }

        public void OnSelected(Object sender, EventArgs args)
        {
            string type = (sender as ViewCell).Id.ToString();

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Inspection inspection = (e.Item as Inspection);
            Navigation.PushAsync(new ProductList(inspection.Id));
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
