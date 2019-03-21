using LineBot.Models.WebhookEvents.Postback;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents
{
    public class PostbackEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        
        [JsonProperty("postback")]
        public PostBack Postback;
    }
}
