﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace LineBot
{
    public class WebRequestHelper
    {
        public static string PostLineApi(string url, string body,string channelAccessToken)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + channelAccessToken);

            byte[] byteData = Encoding.UTF8.GetBytes(body);
            request.ContentLength = byteData.Length;
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            // 取得迴應數據
            return GetResponse(request);
        }

        private static string GetResponse(HttpWebRequest request)
        {
            string result = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }
    }
}