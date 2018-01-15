using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class ShortUrl
    {
        [JsonProperty("sid")]
        public string Sid { set; get; }

        [JsonProperty("long_url")]
        public string Long { set; get; }

        [JsonProperty("short_url")]
        public string Short { set; get; }

        [JsonProperty("enter_url")]
        public string Enter { set; get; }

        [JsonProperty("name")]
        public string Name { set; get; }

        [JsonProperty("stat_expire")]
        public string StatExpire { set; get; }
    }
}