using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class VoiceSend
    {
        [JsonProperty("sid")]
        public string Sid { set; get; }

        [JsonProperty("count")]
        public int Count { set; get; }

        [JsonProperty("fee")]
        public double Fee { set; get; }
    }
}