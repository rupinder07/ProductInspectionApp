using Newtonsoft.Json;
using ProductInspection.Model;
using ProductInspection.View;
using ProductInspection.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspections.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InspectionList : ContentPage
    {
        private InspectionListViewModel viewModel;

        public InspectionList()
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
    }

}