using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class Event
    {
        public const string MESSAGE_TYPE = "message";
        public const string FOLLOW_TYPE = "follow";
        public const string UNFOLLOW_TYPE = "unfollow";
        public const string JOIN_TYPE = "join";
        public const string LEAVE_TYPE = "leave";
        public const string MEMBER_JOIN_TYPE = "memberJoined";
        public const string MEMBER_LEAVE_TYPE = "memberLeft";
        public const string POST_BACK_TYPE = "postback";
        public const string BEACON_TYPE = "beacon";
        public const string ACCOUNT_LINK_TYPE = "accountLink";
        public const string DEVICE_UN_LINK_TYPE = "things";

        //Identifier for the type of event
        [JsonProperty("type")]
        public string Type;
    }
}
