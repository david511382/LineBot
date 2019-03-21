using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.WebhookEvents.Member
{
    public class Members
    {
        //User ID of users who joined
        [JsonProperty("members")]
        public Source[] Sources;
    }
}
