using Newtonsoft.Json;

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

        public AccountLinkEvent()
         : base(ACCOUNT_LINK_TYPE)
        {

        }
    }
}
