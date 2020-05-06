using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class EventRequest
    {
        [JsonProperty("destination")]
        public string Destination;

        [JsonProperty("events")]
        public Event[] Events;
    }
}
