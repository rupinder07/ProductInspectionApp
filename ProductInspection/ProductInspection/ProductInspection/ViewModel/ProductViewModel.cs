using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProductInspection.Model;
using ProductInspection.Services;
using Newtonsoft.Json;

namespace ProductInspection.View
{
    class ProductViewModel
    {

        public Product _product;

        public Product Product {
            get { return _product; }
            set { _product = value; }
        }

        internal async void FetchProductById(string inspectionId, string productId)
        {
            try
            {
                var response = await RestClient.HttpClient.GetStringAsync(String.Format("inspection/{0}/product/{1}", inspectionId, productId));
                Product = JsonConvert.DeserializeObject<Product>(response);
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }

        internal async Task<HttpStatusCode> OnSubmit()
        {
            var json = JsonConvert.SerializeObject(Product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string uri = String.Format("inspection/{0}/product/{1}", Product.InspectionId, Product.Id);
            var response = await RestClient.HttpClient.PutAsync(uri, content);
            return response.StatusCode;
        }
    }
}
