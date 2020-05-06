using Newtonsoft.Json;

namespace LineBot.Models.ReplyMessage
{
    public class Request
    {
        [JsonProperty("replyToken")]
        public string ReplyToken;

        [JsonProperty("messages")]
        public WebhookEvents.Message.Message[] Messages;
    }
}
