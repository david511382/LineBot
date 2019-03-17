using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.MulticastMessage
{
    public class Request
    {
        [JsonProperty("to")]
        public string[] To;

        [JsonProperty("messages")]
        public WebhookEvents.Message.Text.Message[] Messages;
    }
}
