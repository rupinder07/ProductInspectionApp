using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace ProductInspection.Model
{
    public class Product : INotifyPropertyChanged
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inspectionId")]
        public string InspectionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stateSatisfactory")]
        public bool StateSatisfactory { get; set; }

        [JsonProperty("requiresMaintenance")]
        public bool RequiresMaintenance { get; set; }

        [JsonProperty("inspectionDateTime")]
        public DateTime InspectionDateTime { get; set; } = DateTime.Now;

        private string _comments;

        [JsonProperty("comments")]
        public string Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Comments"));
                }
            }
        }

        [JsonProperty("image")]
        public Stream Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
