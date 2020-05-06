using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents.Postback
{
    public class PostBack
    {
        //Postback data
        [JsonProperty("data")]
        public string Data;

        //JSON object
        [JsonProperty("params")]
        public object Params;
    }
}
