using Newtonsoft.Json;

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
        [JsonProperty("userId")]
        public string UserID;

        [JsonProperty("groupId")]
        public string GroupID;

        [JsonProperty("roomId")]
        public string RoomID;
    }
}
