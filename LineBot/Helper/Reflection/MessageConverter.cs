using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace LineBot.Helper.Reflection
{
    //自訂轉換器，繼承CustomCreationConverter<T>
    public class MessageConverter : CustomCreationConverter<Message>
    {
        //由於ReadJson會依JSON內容建立不同物件，用不到Create()
        public override Message Create(Type objectType)
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
                case Message.TEXT_TYPE:
                    TextMessage text = new LineBot.Models.WebhookEvents.Message.TextMessage();
                    serializer.Populate(jo.CreateReader(), text);
                    return text;
                case Message.IMAGE_TYPE:
                case Message.VIDEO_TYPE:
                    MediaMessage media = new LineBot.Models.WebhookEvents.Message.MediaMessage();
                    serializer.Populate(jo.CreateReader(), media);
                    return media;
                case Message.AUDIO_TYPE:
                    AudioMessage audio = new LineBot.Models.WebhookEvents.Message.AudioMessage();
                    serializer.Populate(jo.CreateReader(), audio);
                    return audio;
                case Message.LOCATION_TYPE:
                    LocationMessage location = new LineBot.Models.WebhookEvents.Message.LocationMessage();
                    serializer.Populate(jo.CreateReader(), location);
                    return location;
                case Message.STICER_TYPE:
                    StickerMessage sticker = new LineBot.Models.WebhookEvents.Message.StickerMessage();
                    serializer.Populate(jo.CreateReader(), sticker);
                    return sticker;
                default:
                    throw new ApplicationException("Unsupported type: " + type);
            }
        }
    }
}