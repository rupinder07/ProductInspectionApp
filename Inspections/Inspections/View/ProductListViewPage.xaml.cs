using Inspections.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspections.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ProductList()
        {
            InitializeComponent();
            ProductListViewModel vm = new ProductListViewModel();
            BindingContext = vm;
            vm.Products.Add(new Model.Product() { Name = "Product 1"});
			ProductListView.ItemsSource = vm.Products;
        }

        private void OnTapped(object sender, EventArgs e) => Navigation.PushAsync(new NavigationPage(new ProductView()));
            
            
        
    }
}
