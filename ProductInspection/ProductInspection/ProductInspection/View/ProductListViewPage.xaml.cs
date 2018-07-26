using ProductInspection.ViewModel;
using ProductInspection.Model;
using ProductInspection.Services;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductInspection.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
    
        ProductListViewModel vm = new ProductListViewModel();

        public ProductList(string id)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.FetchProoductsByInspectionId(id);
        }

        private void ProductListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Product product = e.Item as Product;
            Navigation.PushAsync(new ProductView(product.InspectionId, product.Id));
        }
    }
}
