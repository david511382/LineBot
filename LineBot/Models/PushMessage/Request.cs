using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.PushMessage
{
    public class Request
    {
        [JsonProperty("to")]
        public string To;

        [JsonProperty("messages")]
        public WebhookEvents.Message.Message[] Messages;
    }
}
