using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
