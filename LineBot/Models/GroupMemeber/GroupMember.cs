using Newtonsoft.Json;

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
