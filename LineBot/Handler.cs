using LineBot.Helper.Reflection;
using LineBot.Models;
using LineBot.Models.Profile;
using LineBot.Models.WebhookEvents;
using LineBot.Models.WebhookEvents.Message;
using LineBot.Models.WebhookEvents.Message.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LineBot
{
    public class Handler
    {
        const string LINE_URL = "https://api.line.me/v2/bot";

        public EventRequest ParseRequest(Stream body)
        {
            if (body.Length > int.MaxValue)
                throw new Exception("data too big");

            int dataLen = (int)body.Length;
            byte[] bodyByte = new byte[dataLen];
            body.Read(bodyByte, 0, dataLen);

            string bodyStr = Encoding.UTF8.GetString(bodyByte);
            EventRequest data;
            try
            {
                data = JsonConvert.DeserializeObject<EventRequest>(bodyStr, new WebhookEventConverter());
            }
            catch
            {
                throw new Exception("json convert fail");
            }

            return data;
        }

        public EventRequest ParseRequest(HttpWebRequest request)
        {
            using (Stream postStream = request.GetRequestStream())
            {
                return ParseRequest(postStream);
            }
        }

        // POST https://api.line.me/v2/bot/message/reply
        public string ReplyMessage(string replyToken, Message[] msgs, string channelAccessToken)
        {
            Models.ReplyMessage.Request body = new Models.ReplyMessage.Request();
            body.ReplyToken = replyToken;

            if (!Is1To5(msgs))
                throw new Exception("wrong length");

            body.Messages = msgs;

            string data = JsonConvert.SerializeObject(body);
            return WebRequestHelper.PostLineApi(LINE_URL + "/message/reply", data, channelAccessToken);
        }

        // POST https://api.line.me/v2/bot/message/push
        // to a user, group, or room a
        public string PushMessage(string targetID, Message[] msgs, string channelAccessToken)
        {
            Models.PushMessage.Request body = new Models.PushMessage.Request();
            body.To = targetID;

            if (!Is1To5(msgs))
                throw new Exception("wrong length");

            body.Messages = msgs;

            string data = JsonConvert.SerializeObject(body);
            return WebRequestHelper.PostLineApi(LINE_URL + "/message/push", data, channelAccessToken);
        }

        // POST https://api.line.me/v2/bot/message/multicast
        // to multiple users
        public string MulticastMessage(string[] userIDs, Message[] msgs, string channelAccessToken)
        {
            Models.MulticastMessage.Request body = new Models.MulticastMessage.Request();
            body.To = userIDs;

            if (!Is1To5(msgs))
                throw new Exception("wrong length");

            body.Messages = msgs;


            string data = JsonConvert.SerializeObject(body);
            return WebRequestHelper.PostLineApi(LINE_URL + "/message/multicast", data, channelAccessToken);
        }

        // POST https://api.line.me/v2/bot/profile/{userID}
        // to multiple users
        public Profile GetProfile(string userID, string channelAccessToken)
        {
            string jsStr = WebRequestHelper.PostLineApi(LINE_URL + "/profile/" + userID, "", channelAccessToken);
            Profile profile = JsonConvert.DeserializeObject<Profile>(jsStr);
            return profile;
        }

        private bool Is1To5(object[] msgs)
        {
            const int MAX = 5;
            int len = msgs.Length;

            if (len > MAX || len == 0)
                return false;
            return true;
        }
    }
}
