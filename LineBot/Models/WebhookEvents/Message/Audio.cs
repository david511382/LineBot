using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
