using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace ProductInspection.Model
{
    public class Product : IBaseEntity, INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("inspectionId")]
        public int InspectionId { get; set; }

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

        //[JsonProperty("lastSyncTime")]
        //public string lastSyncTime { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime LastSyncTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool PushDownstream { get; set; } = false;
    }

    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
