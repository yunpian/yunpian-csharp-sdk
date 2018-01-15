using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class SmsSingleSend
    {
        [JsonProperty("code")]
        public int Code { set; get; }

        [JsonProperty("msg")]
        public string Msg { set; get; }

        [JsonProperty("count")]
        public int Count { set; get; }

        [JsonProperty("fee")]
        public double Fee { set; get; }

        [JsonProperty("unit")]
        public string Unit { set; get; }

        [JsonProperty("mobile")]
        public string Mobile { set; get; }

        [JsonProperty("sid")]
        public long Sid { set; get; }
    }
}