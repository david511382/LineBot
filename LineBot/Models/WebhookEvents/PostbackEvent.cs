using LineBot.Models.WebhookEvents.Postback;
using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class PostbackEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;


        [JsonProperty("postback")]
        public PostBack Postback;

        public PostbackEvent()
          : base(POST_BACK_TYPE)
        {

        }
    }
}
