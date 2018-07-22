using Inspections.Model;
using Inspections.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Inspections.ViewModel
{
    class ProductListViewModel
    {
        private const string BACKEND_URL = "http://172.20.10.3:8080/inspection/";

        public ObservableCollection<Product> _products = new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }

            set
            {
                _products = value;
            }
        }

        public async void FetchProoductsByInspectionId(string id)
        {
            var response = await new RestClient().HttpClient.GetStringAsync(BACKEND_URL + id + "/product");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(response);
            products.ForEach(Products.Add);
        }


    }
}
