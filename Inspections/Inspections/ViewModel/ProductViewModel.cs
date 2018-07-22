using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Inspections.Model;
using Inspections.Services;
using Newtonsoft.Json;

namespace Inspections.View
{
    class ProductViewModel
    {

        public Product _product;

        public Product Product {
            get { return _product; }
            set {
                _product = value;
            }
        }

        internal async void FetchProductById(string inspectionId, string productId)
        {
            var response = await new RestClient().HttpClient.GetStringAsync(String.Format("http://172.20.10.3:8080/inspection/{0}/product/{1}", inspectionId, productId));
            Product = JsonConvert.DeserializeObject<Product>(response);
        }

        internal async Task<HttpStatusCode> OnSubmit()
        {
            var json = JsonConvert.SerializeObject(Product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string uri = String.Format("http://172.20.10.3:8080/inspection/{0}/product/{1}", Product.InspectionId, Product.Id);
            var response = await new RestClient().HttpClient.PutAsync(uri, content);
            return response.StatusCode;
        }
    }
}
