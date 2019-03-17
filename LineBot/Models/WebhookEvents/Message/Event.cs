using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message
{
    public class Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        //Identifier for the type of event
        [JsonProperty("type")]
        public string Type;

        //Time of the event in milliseconds
        [JsonProperty("timestamp")]
        public long Timestamp;

        //Source user, group, or room object with information about the source of the event.
        [JsonProperty("source")]
        public Source Source;

        //Object containing the contents of the message. Message types include:
        [JsonProperty("message")]
        public Text.Message Message;
    }
}
