using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class LeaveEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        //Time of the event in milliseconds
        [JsonProperty("timestamp")]
        public long Timestamp;

        //Source user, group, or room object with information about the source of the event.
        [JsonProperty("source")]
        public Source Source;

        //Object containing the contents of the message. Message types include:
        [JsonProperty("message")]
        public Message.Message Message;

        public LeaveEvent()
           : base(LEAVE_TYPE)
        {

        }
    }
}
