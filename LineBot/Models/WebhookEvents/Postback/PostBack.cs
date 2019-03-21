using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
