using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents
{
    public class AccountLinkEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        //This will include whether the account link was successful or not and a nonce generated from the user ID on the provider's service.
        [JsonProperty("link")]
        public object Link;
    }
}
