using LineBot.Helper.Reflection;
using LineBot.Models.WebhookEvents;
using LineBot.Models.WebhookEvents.Member;
using LineBot.Models.WebhookEvents.Message;
using LineBotTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace LineBotTest
{
    [TestClass]
    public class JsonConverterTest
    {
        [TestMethod]
        public void ConverterTest()
        {
            const string input = @"
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
                            ""timestamp"": 1231321,
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
                            ""timestamp"": 1231321,
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
            EventRequest want = new EventRequest
            {
                Destination = "U9ebdd473d2415d19f58642e1734974f",
                Events = new Event[] {
                    new MessageEvent {
                        ReplyToken="98645878f3dcae996c83b3fb483b7c3e",
                        Timestamp=1588685138631,
                        Source=new Source
                        {
                            Type="user",
                            UserID="U16cb23db6619b551c5729daebe6396ee",
                        },
                        Message=new TextMessage()
                        {
                            Text="some message"
                        }
                    },
                    new MessageEvent {
                        ReplyToken="0f3779fba5d07d3b349968cb31eab56f",
                        Timestamp=1231321,
                        Source=new Source
                        {
                            Type="group",
                            UserID="U4af4980629...",
                            GroupID="gggg4980629...",
                        },
                        Message=new TextMessage()
                        {
                            Text = "test message"
                        }
                    },
                    new MessageEvent {
                        ReplyToken="8cf9239d56244f4197887e939187e19e",
                        Timestamp=1231321,
                        Source=new Source
                        {
                            Type="user",
                            UserID="U4af4980629...",
                        },
                        Message=new StickerMessage()
                        {
                            PackageID ="1",
                           StickerID="13",
                        }
                    },
                    new MemberJoinEvent{
                        ReplyToken="0f37b349968c5d79fba307db31eabf65",
                        JoinMembers = new Members
                        {
                            Sources = new Source[]
                            {
                                new Source{
                                    Type="user",
                                    UserID="U4af4980629..."
                                },
                                new Source{
                                    Type="user",
                                    UserID="U91eeaf62d9..."
                                },
                            },
                        },
                    },
                },
            };

            EventRequest got;
            try
            {
                got = JsonConvert.DeserializeObject<EventRequest>(input, new WebhookEventConverter());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return;
            }

            ReflectionCompare.Compare(got, want);
        }
    }
}
