using LineBot.Models;
using LineBot.Models.WebhookEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LineBotTest
{
    [TestClass]
    public class JsonModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string data = "{\r\n  \"destination\": \"xxxxxxxxxx\", \r\n  \"events\": [\r\n    {\r\n      \"replyToken\": \"0f3779fba3b349968c5d07db31eab56f\",\r\n      \"type\": \"message\",\r\n      \"timestamp\": 1462629479859,\r\n      \"source\": {\r\n        \"type\": \"user\",\r\n        \"userId\": \"U4af4980629...\"\r\n      },\r\n      \"message\": {\r\n        \"id\": \"325708\",\r\n        \"type\": \"text\",\r\n        \"text\": \"Ke Listen\"\r\n      }\r\n    },\r\n    {\r\n      \"replyToken\": \"8cf9239d56244f4197887e939187e19e\",\r\n      \"type\": \"follow\",\r\n      \"timestamp\": 1462629479859,\r\n      \"source\": {\r\n        \"type\": \"user\",\r\n        \"userId\": \"U4af4980629...\"\r\n      }\r\n    }\r\n  ]\r\n}";
            EventRequest result = JsonConvert.DeserializeObject<EventRequest>(data);

            Assert.AreEqual(result.Events[1].Source.UserID, "U4af4980629...");
        }
    }
}
