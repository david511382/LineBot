﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message.Media
{
    public class MediaMessage : Message
    {
        public static readonly MediaMessage DOG;
        static MediaMessage()
        {
            DOG = new MediaMessage();
            DOG.Type = "image";
            DOG.OriginalContentURL = "https://farm8.staticflickr.com/7822/46577101464_b8e1a7e1db_b.jpg";
            DOG.PreviewImageURL = "https://farm8.staticflickr.com/7822/46577101464_b8e1a7e1db_m.jpg";
        }

        // Image URL(Max: 1000 characters) HTTPS JPEG Max: 1024 x 1024 Max: 1 MB
        // URL of video file (Max: 1000 characters) HTTPS mp4 Max: 1 minute Max: 10 MB
        // A very wide or tall video may be cropped when played in some environments.
        [JsonProperty("originalContentUrl")]
        public string OriginalContentURL;

        // URL of preview image (Max: 1000 characters) HTTPS JPEG Max: 240 x 240 Max: 1 MB
        [JsonProperty("previewImageUrl")]
        public string PreviewImageURL;
    }
}
