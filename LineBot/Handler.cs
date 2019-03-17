using LineBot.Models;
using LineBot.Models.Profile;
using LineBot.Models.WebhookEvents;
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
            EventRequest data = JsonConvert.DeserializeObject<EventRequest>(bodyStr);

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
        public string ReplyMessage(string replyToken, string[] msgs, string channelAccessToken)
        {
            Models.ReplyMessage.Request body = new Models.ReplyMessage.Request();
            body.ReplyToken = replyToken;
            try
            {
                body.Messages = Limit5Msg(msgs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string data = JsonConvert.SerializeObject(body);
            return WebRequestHelper.PostLineApi(LINE_URL + "/message/reply", data, channelAccessToken);
        }

        // POST https://api.line.me/v2/bot/message/push
        // to a user, group, or room a
        public string PushMessage(string targetID, string[] msgs, string channelAccessToken)
        {
            Models.PushMessage.Request body = new Models.PushMessage.Request();
            body.To = targetID;
            try
            {
                body.Messages = Limit5Msg(msgs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string data = JsonConvert.SerializeObject(body);
            return WebRequestHelper.PostLineApi(LINE_URL + "/message/push", data, channelAccessToken);
        }

        // POST https://api.line.me/v2/bot/message/multicast
        // to multiple users
        public string MulticastMessage(string[] userIDs, string[] msgs, string channelAccessToken)
        {
            Models.MulticastMessage.Request body = new Models.MulticastMessage.Request();
            body.To = userIDs;
            try
            {
                body.Messages = Limit5Msg(msgs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        private Models.WebhookEvents.Message.Text.Message[] Limit5Msg(string[] msgs)
        {
            msgs = msgs
                .Where(m => !string.IsNullOrEmpty(m))
                .ToArray();

            const int MAX = 5;
            int len = msgs.Length;
            if (len > MAX)
                len = MAX;
            else if (len == 0)
                throw new Exception("no message");

            Models.WebhookEvents.Message.Text.Message[] messages = new Models.WebhookEvents.Message.Text.Message[len];
            for (int i = 0; i < len; i++)
            {
                messages[i] = new Models.WebhookEvents.Message.Text.Message();
                messages[i].Text = msgs[i];
                messages[i].Type = "text";
            }

            return messages;
        }
    }
}
