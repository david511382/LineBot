using LineBot.Helper.Reflection;
using LineBot.Models.GroupMember;
using LineBot.Models.Profile;
using LineBot.Models.WebhookEvents;
using LineBot.Models.WebhookEvents.Message;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace LineBot
{
    public class Handler
    {
        const string LINE_URL = "https://api.line.me/v2/bot";

        public EventRequest ParseRequest(Stream body)
        {
            StreamReader reader = new StreamReader(body);
            string bodyStr = reader.ReadToEnd();
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

            if (!is1To5(msgs))
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

            if (!is1To5(msgs))
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

            if (!is1To5(msgs))
                throw new Exception("wrong length");

            body.Messages = msgs;


            string data = JsonConvert.SerializeObject(body);
            return WebRequestHelper.PostLineApi(LINE_URL + "/message/multicast", data, channelAccessToken);
        }

        // POST https://api.line.me/v2/bot/profile/{userID}
        public Profile GetProfile(string userID, string channelAccessToken)
        {
            string jsStr = WebRequestHelper.GetLineApi(LINE_URL + "/profile/" + userID, channelAccessToken);
            Profile profile = JsonConvert.DeserializeObject<Profile>(jsStr);
            return profile;
        }

        // POST https://api.line.me/v2/bot/message/{messageId}/content
        public byte[] GetContent(string messageId, string channelAccessToken)
        {
            string str = WebRequestHelper.GetLineApi(LINE_URL + "/message/" + messageId + "/content", channelAccessToken);

            return Encoding.Default.GetBytes(str);
        }

        // POST https://api.line.me/v2/bot/group/{groupID}/members/ids
        // Get group member user IDs
        public GroupMember GetGroupMemberID(string groupID, string channelAccessToken, string start = "")
        {
            if (!string.IsNullOrEmpty(start))
                start = "?start=" + start;

            string jsStr = WebRequestHelper.GetLineApi(LINE_URL + "/group/" + groupID + "/members/ids" + start, channelAccessToken);
            GroupMember gm = JsonConvert.DeserializeObject<GroupMember>(jsStr);
            return gm;
        }

        private bool is1To5(object[] msgs)
        {
            const int MAX = 5;
            int len = msgs.Length;

            if (len > MAX || len == 0)
                return false;
            return true;
        }
    }
}
