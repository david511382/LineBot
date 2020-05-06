using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents.Member
{
    public class Members
    {
        //User ID of users who joined
        [JsonProperty("members")]
        public Source[] Sources;
    }
}
