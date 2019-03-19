using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message.Location
{
    public class LocationMessage : Message
    {
        // Max: 100 characters
        [JsonProperty("title")]
        public string Title;

        // Max: 100 characters
        [JsonProperty("address")]
        public String Address;

        // Latitude
        [JsonProperty("latitude")]
        public decimal Latitude;

        // Longitude
        [JsonProperty("longitude")]
        public decimal Longitude;
    }
}
