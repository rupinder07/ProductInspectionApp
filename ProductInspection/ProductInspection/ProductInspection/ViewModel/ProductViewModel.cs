using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProductInspection.Model;
using ProductInspection.Services;
using Newtonsoft.Json;
using ProductInspection.repository;
using System.Collections.Generic;

namespace ProductInspection.View
{
    class ProductViewModel : INotifyPropertyChanged
    {

        private BaseRepository<Product> ProductRepository = new BaseRepository<Product>(); 
        public Product _product;

        public event PropertyChangedEventHandler PropertyChanged;

        public Product Product {
            get {
                return _product;
            }
            set {
                _product = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Product"));
            }
        }

        internal async void FetchProductById(int inspectionId, int productId)
        {
            try
            {
                var response = await RestClient.HttpClient.GetStringAsync(
                    String.Format("inspection/{0}/product/{1}", inspectionId, productId)
                    );
                Product = JsonConvert.DeserializeObject<Product>(response);
            }
            catch(Exception e)
            {
                Console.Write(e);
                //fetch product details from Local Storage
                List<Product> products = await ProductRepository.GetItemById("product", productId);
                if(products.Count > 0)
                {
                    Product = products.ToArray()[0];
                }
            }
        }

        internal void OnSubmit()
        {
            if(Product != null)
            {
                Product.LastSyncTime = DateTime.Now;
                try
                {
                    Event currentEvent = new Event()
                    {
                        Id = Product.Id,
                        Operation = HttpOperation.UPDATE,
                        Entity = Product,
                        URI = String.Format("inspection/{0}/product/{1}", Product.InspectionId, Product.Id),
                        TableName = "Product"
                    };
                    SyncService.PushAsync(currentEvent);
                }
                catch (Exception e)
                {
                    Console.Out.Write(e);
                }
            }
           
        }
    }
}
