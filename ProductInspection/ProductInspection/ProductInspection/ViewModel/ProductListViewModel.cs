using Newtonsoft.Json;
using ProductInspection.Model;
using ProductInspection.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProductInspection.ViewModel
{
    class ProductListViewModel
    {

        public ObservableCollection<Product> _products = new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public async void FetchProoductsByInspectionId(string id)
        {
            try
            {
                var response = await RestClient.HttpClient.GetStringAsync("inspection/" + id + "/product");
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(response);
                products.ForEach(Products.Add);
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }
    }
}
