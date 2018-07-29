using Newtonsoft.Json;
using ProductInspection.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInspection.Model
{
    public class User
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [JsonProperty("username")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
