using Newtonsoft.Json;
using ProductInspection.Model;
using ProductInspection.repository;
using ProductInspection.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProductInspection.ViewModel
{
    class ProductListViewModel
    {
        private BaseRepository<Product> ProductRepository = new BaseRepository<Product>();

        public ObservableCollection<Product> _products = new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public async void FetchProoductsByInspectionId(int id)
        {
            if (await SyncService.IsBackendReachable())
            {
                try
                {
                    var response = await RestClient.HttpClient.GetStringAsync("inspection/" + id + "/product");
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(response);
                    products.ForEach(Products.Add);

                    //Update the products in local DB so as to support offline application

                    UpdateProductsInLocalStorage(products);
                }
                catch
                {
                    List<Product> products = await ProductRepository.GetItemsAsync();
                    products.ForEach(Products.Add);
                }
            }
            else
            {
                List<Product> products = await ProductRepository.GetItemsAsync();
                products.ForEach(Products.Add);
            }
        }

        private void UpdateProductsInLocalStorage(List<Product> products)
        {
            ProductRepository.DeleteAllItems("Product");
            ProductRepository.SaveAllItemsAsync(products);
        }

        private void AddNewInspectionsIfAny(List<Product> products, List<Product> existingProducts)
        {
            DateTime LastSyncTime = DateTime.MinValue;
            existingProducts.ForEach(product =>
            {
                if (product.LastSyncTime.CompareTo(LastSyncTime) > 0)
                {
                    LastSyncTime = product.LastSyncTime;
                }
            });

            List<Product> productsToAdd = products.FindAll(inspection =>
                inspection.LastSyncTime.CompareTo(LastSyncTime) > 0
            );

            ProductRepository.SaveAllItemsAsync(productsToAdd);
        }
    }
}
