using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class FollowJoinEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        public FollowJoinEvent()
            : base(FOLLOW_TYPE)
        {

        }
    }
}
