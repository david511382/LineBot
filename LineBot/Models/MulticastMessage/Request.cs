using Newtonsoft.Json;

namespace LineBot.Models.MulticastMessage
{
    public class Request
    {
        [JsonProperty("to")]
        public string[] To;

        [JsonProperty("messages")]
        public WebhookEvents.Message.Message[] Messages;
    }
}
