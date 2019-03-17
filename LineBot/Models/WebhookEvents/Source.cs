﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents
{
        //user,
        //group,
        //room

    public class Source
    {
        // public string Type => this.Type.ToString();
        [JsonProperty("type")]
        public string Type;

        //ID of the source user.Only included in message events.Not included if the user has not agreed to the Official Accounts Terms of Use.
        [JsonProperty("userid")]
        public string UserID;

        [JsonProperty("groupid")]
        public string GroupID;

        [JsonProperty("roomid")]
        public string RoomID;
    }
}
