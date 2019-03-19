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
        ""type"": ""user"",
        ""userId"": ""U4af4980629...""
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
    }
  ]
}";
            EventRequest result = JsonConvert.DeserializeObject<EventRequest>(data, new WebhookEventConverter()); 
            Assert.AreEqual(result.Events[1].Source.UserID, "U4af4980629...");
            Assert.AreEqual(result.Events[0].Message.Type, "text");

            LineBot.Models.WebhookEvents.Message.Sticker.StickerMessage sticker = result.Events[1].Message as LineBot.Models.WebhookEvents.Message.Sticker.StickerMessage;
            Assert.AreEqual(sticker.StickerID, "13");
            Assert.AreEqual(sticker.Type, "sticker");
        }
    }
}
