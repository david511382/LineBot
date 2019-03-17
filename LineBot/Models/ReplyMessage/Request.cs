using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.ReplyMessage
{
    public class Request
    {
        [JsonProperty("replyToken")]
        public string ReplyToken;

        [JsonProperty("messages")]
        public WebhookEvents.Message.Text.Message[] Messages;
    }
}
