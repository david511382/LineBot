using Newtonsoft.Json;

namespace LineBot.Models.WebhookEvents.Message
{
    public class TextMessage : Message
    {
        public static readonly string LIGHT_BULB = @"\u0x100077";

        public TextMessage()
            : base(TEXT_TYPE)
        {
        }

        public static implicit operator TextMessage(string s)
        {
            TextMessage t = new TextMessage();
            t.Text = s;

            return t;
        }

        public static TextMessage[] Convert(string[] s)
        {
            int len = s.Length;
            TextMessage[] ts = new TextMessage[len];
            for (int i = 0; i < len; i++)
            {
                ts[i] = s[i];
            }

            return ts;
        }

        // Message text. You can include the following emoji:
        // Unicode emoji
        // LINE original emoji(Unicode codepoint table for LINE original emoji)
        // Max: 2000 characters
        [JsonProperty("text")]
        public string Text;
    }
}
