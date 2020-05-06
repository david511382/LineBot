using LineBot;
using LineBot.Helper.Reflection;
using LineBot.Models.WebhookEvents;
using LineBot.Models.WebhookEvents.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace LineBotTest
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void TestParseRequest()
        {
            const string data = @"
                {
                    ""events"": [
                        {
                            ""type"": ""message"",
                            ""replyToken"": ""98645878f3dcae996c83b3fb483b7c3e"",
                            ""source"": {
                                ""userId"": ""U16cb23db6619b551c5729daebe6396ee"",
                                ""type"": ""user""
                            },
                            ""timestamp"": 1588685138631,
                            ""mode"": ""active"",
                            ""message"": {
                                ""type"": ""text"",
                                ""id"": ""11982107614650"",
                                ""text"": ""some message""
                            }
                        },
                        {
                            ""replyToken"": ""0f3779fba5d07d3b349968cb31eab56f"",
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
                                ""text"": ""test message""
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
                            ""replyToken"": ""0f37b349968c5d79fba307db31eabf65"",
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
                    ],
                    ""destination"": ""U9ebdd473d2415d19f58642e1734974f""
                }
            ";
            byte[] byteArray = Encoding.ASCII.GetBytes(data);
            MemoryStream input = new MemoryStream(byteArray);
            EventRequest want = JsonConvert.DeserializeObject<EventRequest>(data, new WebhookEventConverter());

            Handler handler = new Handler();

            EventRequest got = handler.ParseRequest(input);

            Assert.AreEqual(got.Destination, want.Destination);

            Event gotEvent1 = got.Events[0];
            Event wantEvent1 = want.Events[0];
            Assert.AreEqual(gotEvent1.Type, wantEvent1.Type);
            MessageEvent gotMessage = (MessageEvent)gotEvent1;
            MessageEvent wantMessage = (MessageEvent)wantEvent1;
            Assert.AreEqual(gotMessage.Type, wantMessage.Type);
            Assert.AreEqual(gotMessage.Timestamp, wantMessage.Timestamp);
            Assert.AreEqual(gotMessage.Source.GroupID, wantMessage.Source.GroupID);
            Assert.AreEqual(gotMessage.Source.RoomID, wantMessage.Source.RoomID);
            Assert.AreEqual(gotMessage.Source.Type, wantMessage.Source.Type);
            Assert.AreEqual(gotMessage.Source.UserID, wantMessage.Source.UserID);
            Assert.AreEqual(gotMessage.ReplyToken, wantMessage.ReplyToken);
            Assert.AreEqual(gotMessage.Message.Type, wantMessage.Message.Type);
            TextMessage gotMsg = (TextMessage)gotMessage.Message;
            TextMessage wantMsg = (TextMessage)wantMessage.Message;
            Assert.AreEqual(gotMsg.Type, wantMsg.Type);
            Assert.AreEqual(gotMsg.Text, wantMsg.Text);

            Event gotEvent2 = got.Events[1];
            Event wantEvent2 = want.Events[1];
            Assert.AreEqual(gotEvent1.Type, wantEvent1.Type);
            MessageEvent gotMessage2 = (MessageEvent)gotEvent2;
            MessageEvent wantMessage2 = (MessageEvent)wantEvent2;
            Assert.AreEqual(gotMessage2.Type, wantMessage2.Type);
            Assert.AreEqual(gotMessage2.Timestamp, wantMessage2.Timestamp);
            Assert.AreEqual(gotMessage2.Source.GroupID, wantMessage2.Source.GroupID);
            Assert.AreEqual(gotMessage2.Source.RoomID, wantMessage2.Source.RoomID);
            Assert.AreEqual(gotMessage2.Source.Type, wantMessage2.Source.Type);
            Assert.AreEqual(gotMessage2.Source.UserID, wantMessage2.Source.UserID);
            Assert.AreEqual(gotMessage2.ReplyToken, wantMessage2.ReplyToken);
            Assert.AreEqual(gotMessage2.Message.Type, wantMessage2.Message.Type);
            TextMessage gotMsg2 = (TextMessage)gotMessage2.Message;
            TextMessage wantMsg2 = (TextMessage)wantMessage2.Message;
            Assert.AreEqual(gotMsg2.Type, wantMsg2.Type);
            Assert.AreEqual(gotMsg2.Text, wantMsg2.Text);

            Event gotEvent3 = got.Events[2];
            Event wantEvent3 = want.Events[2];
            Assert.AreEqual(gotEvent1.Type, wantEvent1.Type);
            MessageEvent gotMessage3 = (MessageEvent)gotEvent3;
            MessageEvent wantMessage3 = (MessageEvent)wantEvent3;
            Assert.AreEqual(gotMessage3.Type, wantMessage3.Type);
            Assert.AreEqual(gotMessage3.Timestamp, wantMessage3.Timestamp);
            Assert.AreEqual(gotMessage3.Source.GroupID, wantMessage3.Source.GroupID);
            Assert.AreEqual(gotMessage3.Source.RoomID, wantMessage3.Source.RoomID);
            Assert.AreEqual(gotMessage3.Source.Type, wantMessage3.Source.Type);
            Assert.AreEqual(gotMessage3.Source.UserID, wantMessage3.Source.UserID);
            Assert.AreEqual(gotMessage3.ReplyToken, wantMessage3.ReplyToken);
            Assert.AreEqual(gotMessage3.Message.Type, wantMessage3.Message.Type);
            StickerMessage gotMsg3 = (StickerMessage)gotMessage3.Message;
            StickerMessage wantMsg3 = (StickerMessage)wantMessage3.Message;
            Assert.AreEqual(gotMsg3.Type, wantMsg3.Type);
            Assert.AreEqual(gotMsg3.StickerID, wantMsg3.StickerID);
            Assert.AreEqual(gotMsg3.PackageID, wantMsg3.PackageID);

            Event gotEvent4 = got.Events[3];
            Event wantEvent4 = want.Events[3];
            Assert.AreEqual(gotEvent1.Type, wantEvent1.Type);
            MemberJoinEvent gotMemberJoin = (MemberJoinEvent)gotEvent4;
            MemberJoinEvent wantMemberJoin = (MemberJoinEvent)wantEvent4;
            Assert.AreEqual(gotMemberJoin.Type, wantMemberJoin.Type);
            for (int i = 0; i < gotMemberJoin.JoinMembers.Sources.Length; i++)
            {
                Source gotMember = gotMemberJoin.JoinMembers.Sources[i];
                Source wantMember = wantMemberJoin.JoinMembers.Sources[i];
                Assert.AreEqual(gotMember.UserID, wantMember.UserID);
                Assert.AreEqual(gotMember.Type, wantMember.Type);
                Assert.AreEqual(gotMember.RoomID, wantMember.RoomID);
                Assert.AreEqual(gotMember.GroupID, wantMember.GroupID);
            }
            Assert.AreEqual(gotMemberJoin.ReplyToken, wantMemberJoin.ReplyToken);
        }
    }
}
