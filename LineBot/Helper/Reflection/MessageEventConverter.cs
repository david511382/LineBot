using LineBot.Models.WebhookEvents;
using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace LineBot.Helper.Reflection
{
    //自訂轉換器，繼承CustomCreationConverter<T>
    public class MessageEventConverter : CustomCreationConverter<Event>
    {
        //由於ReadJson會依JSON內容建立不同物件，用不到Create()
        public override Event Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        //自訂解析JSON傳回物件的邏輯
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            //先取得JobType，由其決定建立物件
            string type = jo["type"].ToString();
            switch (type)
            {
                case Event.MESSAGE_TYPE:
                    reader = jo["message"].CreateReader();
                    MessageConverter messageConverter = new MessageConverter();
                    object message = messageConverter.ReadJson(reader, typeof(Message), existingValue, serializer);

                    var mEv = new MessageEvent();
                    serializer.Populate(jo.CreateReader(), mEv);
                    mEv.Message = (Message)message;
                    return mEv;
                case Event.UNFOLLOW_TYPE:
                case Event.LEAVE_TYPE:
                    var ufEv = new Event();
                    serializer.Populate(jo.CreateReader(), ufEv);
                    return ufEv;
                case Event.POST_BACK_TYPE:
                    var pbEv = new PostbackEvent();
                    serializer.Populate(jo.CreateReader(), pbEv);
                    return pbEv;
                case Event.MEMBER_LEAVE_TYPE:
                    var mlEv = new MemberLeaveEvent();
                    serializer.Populate(jo.CreateReader(), mlEv);
                    return mlEv;
                case Event.MEMBER_JOIN_TYPE:
                    var mjEv = new MemberJoinEvent();
                    serializer.Populate(jo.CreateReader(), mjEv);
                    return mjEv;
                case Event.JOIN_TYPE:
                case Event.FOLLOW_TYPE:
                    var fEv = new FollowJoinEvent();
                    serializer.Populate(jo.CreateReader(), fEv);
                    return fEv;
                case Event.DEVICE_UN_LINK_TYPE:
                    var dulEv = new DeviceULinkEvent();
                    serializer.Populate(jo.CreateReader(), dulEv);
                    return dulEv;
                case Event.BEACON_TYPE:
                    var bEv = new BeaconEvent();
                    serializer.Populate(jo.CreateReader(), bEv);
                    return bEv;
                case Event.ACCOUNT_LINK_TYPE:
                    var alEv = new AccountLinkEvent();
                    serializer.Populate(jo.CreateReader(), alEv);
                    return alEv;
                default:
                    throw new ApplicationException("Unsupported type: " + type);
            }
        }
    }
}