using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents.Things
{
    public class Things
    {
        //Device ID of the LINE Things-compatible device that was linked with LINE
        [JsonProperty("deviceId")]
        public string DeviceID;

        //link
        [JsonProperty("type")]
        public string Type;
    }
}
