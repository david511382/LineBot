using Newtonsoft.Json;
using System;

namespace LineBot.Models.WebhookEvents.Message
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

        public LocationMessage()
            : base(LOCATION_TYPE)
        {
        }
    }
}
