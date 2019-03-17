using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message.Text
{
    public class Message
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("text")]
        public string Text;
    }
}
