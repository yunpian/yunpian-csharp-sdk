using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class SmsReply
    {
        [JsonProperty("base_extend")]
        public string BaseExtend { set; get; }

        [JsonProperty("extend")]
        public string Extend { set; get; }

        [JsonProperty("reply_time")]
        public string ReplyTime { set; get; }

        [JsonProperty("mobile")]
        public string Mobile { set; get; }

        [JsonProperty("text")]
        public string Text { set; get; }

        [JsonProperty("id")]
        public string Id { set; get; }

        [JsonProperty("_sign")]
        public string Sign { set; get; }
    }
}