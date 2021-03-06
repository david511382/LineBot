﻿using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents.Beacon
{
    public class Beacon
    {
        //Hardware ID of the beacon that was detected
        [JsonProperty("hwid")]
        public string HWID;

        //Type of beacon event. See Beacon event types.
        [JsonProperty("type")]
        public string Type;

        //Device message of beacon that was detected.
        [JsonProperty("dm")]
        public string DM;
    }
}
