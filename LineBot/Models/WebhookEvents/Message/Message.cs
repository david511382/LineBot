using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message
{
    public class Message
    {
        public const string TEXT_TYPE = "text";
        public const string IMAGE_TYPE = "image";
        public const string VIDEO_TYPE = "video";
        public const string AUDIO_TYPE = "audio";
        public const string LOCATION_TYPE = "location";
        public const string STICER_TYPE = "sticker";

        [JsonProperty("type")]
        public string Type;
    }
}
