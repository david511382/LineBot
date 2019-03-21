using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBot.Models.GroupMember
{
    public class GroupMember
    {
        [JsonProperty("memberIds")]
        public string[] MemberIDs;

        [JsonProperty("next")]
        public string NextToke;
    }
}
