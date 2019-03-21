using LineBot.Models.WebhookEvents.Member;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents
{
    public class MemberJoinEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        //User ID of users who joined
        [JsonProperty("joined")]
        public Members JoinMembers;
    }
}
