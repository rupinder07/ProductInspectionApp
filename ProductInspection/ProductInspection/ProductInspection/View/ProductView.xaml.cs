using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductInspection.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductView : ContentPage
	{
        ProductViewModel vm = new ProductViewModel();

        public ProductView(string inspectionId, string productId)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.FetchProductById(inspectionId, productId);
        }

        private void ProductSatisfactionSwitchToggled(object sender, ToggledEventArgs e)
        {
        //DisplayAlert("Toggled", vm.ProductStateBinding.StateSatisfactory.ToString(), "OK");
        }

        private void Reset(object sender, EventArgs e)
        {
         //   vm.ProductStateBinding = new Model.ProductState();
        }

        private async void Submit(object sender, EventArgs e)
        {
            HttpStatusCode StatusCode = await vm.OnSubmit();
            await Navigation.PopAsync();
        }
    }
}