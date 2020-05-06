using LineBot.Models.WebhookEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace LineBot.Helper.Reflection
{
    //自訂轉換器，繼承CustomCreationConverter<T>
    public class WebhookEventConverter : CustomCreationConverter<EventRequest>
    {
        //由於ReadJson會依JSON內容建立不同物件，用不到Create()
        public override EventRequest Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        //自訂解析JSON傳回物件的邏輯
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            reader = jo["events"].CreateReader();

            JArray ja = JArray.Load(reader);
            Event[] events = new Event[ja.Count];
            for (int i = 0; i < ja.Count; i++)
            {
                reader = ja[i].CreateReader();
                MessageEventConverter messageEventConverter = new MessageEventConverter();
                object e = messageEventConverter.ReadJson(reader, typeof(Event), existingValue, serializer);
                events[i] = (Event)e;
            }

            EventRequest target = new EventRequest();
            serializer.Populate(jo.CreateReader(), target);
            target.Events = events;
            return target;
        }
    }
}