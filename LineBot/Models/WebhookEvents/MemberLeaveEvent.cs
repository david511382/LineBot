using LineBot.Models.WebhookEvents.Member;
using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents
{
    public class MemberLeaveEvent : Event
    {
        //Token for replying to the event
        [JsonProperty("replyToken")]
        public string ReplyToken;

        //User ID of users who left
        [JsonProperty("left")]
        public Members LeftMembers;

        public MemberLeaveEvent()
            : base(MEMBER_LEAVE_TYPE)
        {

        }
    }
}
