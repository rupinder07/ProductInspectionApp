using Newtonsoft.Json;
using System.ComponentModel;

namespace ProductInspection.Model
{
    public class Inspection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

    }
}
