using LineBot.Helper.Reflection;
using LineBot.Models;
using LineBot.Models.WebhookEvents;
using LineBot.Models.WebhookEvents.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LineBotTest
{
    [TestClass]
    public class JsonModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string data = @"
{
  ""destination"": ""xxxxxxxxxx"",
  ""events"": [
    {
      ""replyToken"": ""0f3779fba3b349968c5d07db31eab56f"",
      ""type"": ""message"",
      ""timestamp"": ""1231321"",
      ""source"": {
        ""type"": ""group"",
        ""userId"": ""U4af4980629..."",
        ""groupId"": ""gggg4980629...""
      },
      ""message"": {
        ""id"": ""325708"",
        ""type"": ""text"",
        ""text"": ""Ke Listen""
      }
    },
    {
      ""replyToken"": ""8cf9239d56244f4197887e939187e19e"",
      ""type"": ""message"",
      ""timestamp"": ""1231321"",
      ""source"": {
        ""type"": ""user"",
        ""userId"": ""U4af4980629...""
      },
      ""message"": {
        ""packageId"": ""1"",
        ""type"": ""sticker"",
        ""stickerId"": ""13""
      }
    },
    {
      ""replyToken"": ""0f3779fba3b349968c5d07db31eabf65"",
      ""type"": ""memberJoined"",
      ""timestamp"": 1462629479859,
      ""source"": {
                    ""type"": ""group"",
        ""groupId"": ""C4af4980629...""
      },
      ""joined"": {
                    ""members"": [
                      {
           ""type"": ""user"",
                        ""userId"": ""U4af4980629...""
          },
          {
            ""type"": ""user"",
            ""userId"": ""U91eeaf62d9...""
          }
        ]
      }
    }
  ]
}";
            EventRequest result = JsonConvert.DeserializeObject<EventRequest>(data, new WebhookEventConverter());
            
            var ev = (MessageEvent)result.Events[0];
            Assert.AreEqual(ev.Message.Type, "text");

            ev = (MessageEvent)result.Events[1];
            Assert.AreEqual(ev.Source.UserID, "U4af4980629...");

            LineBot.Models.WebhookEvents.Message.StickerMessage sticker = ev.Message as LineBot.Models.WebhookEvents.Message.StickerMessage;
            Assert.AreEqual(sticker.StickerID, "13");
            Assert.AreEqual(sticker.Type, "sticker");

            var mjEv = (MemberJoinEvent)result.Events[2];
            Assert.AreEqual(mjEv.JoinMembers.Sources[1].UserID, "U91eeaf62d9...");
        }
    }
}
