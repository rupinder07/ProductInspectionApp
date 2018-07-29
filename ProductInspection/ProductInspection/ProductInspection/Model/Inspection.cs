using Newtonsoft.Json;
using SQLite;
using System;
using System.ComponentModel;
using System.Globalization;

namespace ProductInspection.Model
{
    public class Inspection
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("lastSyncTime")]
        public string lastSyncTime { get; set; }

        public DateTime LastSyncTime
        {
            get
            {
                return DateTime.ParseExact(lastSyncTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
           
        }
    }
}
