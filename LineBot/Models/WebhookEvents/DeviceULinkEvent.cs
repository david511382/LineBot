using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class DeviceULinkEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        [JsonProperty("things")]
        public Things.Things Things;

        public DeviceULinkEvent()
            : base(DEVICE_UN_LINK_TYPE)
        {

        }
    }
}
