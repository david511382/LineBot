using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message
{
        //text,
        //image,
        //video,
        //audio,
        //file,
        //location,
        //sticker

    public class Message
    {
        [JsonProperty("type")]
        public string Type;

        public string ID;

        [JsonProperty("text")]
        public string Text;
        public string contentProvider_type;
        public string contentProvider_originalContentUrl;
        public string contentProvider_previewImageUrl;
        public int duration;
        public string fileName;
        public int fileSize;
        public string title;
        public string address;
        public decimal latitude;
        public decimal longitude;
        public string packageId;
        public string stickerId;
    }
}
