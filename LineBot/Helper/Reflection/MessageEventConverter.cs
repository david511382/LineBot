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
            reader = jo["message"].CreateReader();

            MessageConverter messageConverter = new MessageConverter();
            object message = messageConverter.ReadJson(reader,typeof(Message), existingValue, serializer);

            var target = new Event();
            serializer.Populate(jo.CreateReader(), target);
            target.Message = (Message)message;
            return target;
        }
    }
}