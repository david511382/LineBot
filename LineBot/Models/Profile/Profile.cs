using Newtonsoft.Json;

namespace LineBot.Models.Profile
{
    public class Profile
    {
        [JsonProperty("userId")]
        public string UserID;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("pictureUrl")]
        public string PictureURL;
    }
}
