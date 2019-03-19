﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Message.Sticker
{
    public class StickerMessage : Message
    {
        public static readonly StickerMessage GOOD;
        static StickerMessage()
        {
            GOOD = new StickerMessage();
            GOOD.Type = "sticker";
            GOOD.PackageID = "1";
            GOOD.StickerID = "13";
        }

        // Package ID for a set of stickers. For information on package IDs, see the Sticker list.
        [JsonProperty("packageId")]
        public string PackageID;

        // Sticker ID. For a list of sticker IDs for stickers that can be sent with the Messaging API, see the Sticker list.
        [JsonProperty("stickerId")]
        public string StickerID;
    }
}