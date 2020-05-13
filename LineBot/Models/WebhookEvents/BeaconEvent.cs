using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class BeaconEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        [JsonProperty("beacon")]
        public Beacon.Beacon Beacon;

        public BeaconEvent()
            : base(BEACON_TYPE)
        {

        }
    }
}
