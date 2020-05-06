using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents.Message
{
    public class AudioMessage : Message
    {
        //URL of audio file (Max: 1000 characters) HTTPS m4a Max: 1 minute Max: 10 MB
        [JsonProperty("originalContentUrl")]
        public string OriginalContentURL;

        // Length of audio file (milliseconds)
        [JsonProperty("duration")]
        public int Duration;
    }
}
