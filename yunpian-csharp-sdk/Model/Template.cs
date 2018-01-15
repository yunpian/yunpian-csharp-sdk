using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class Template
    {
        [JsonProperty("tpl_id")]
        public long TplId { set; get; }

        [JsonProperty("tpl_content")]
        public string TplContent { set; get; }

        [JsonProperty("check_status")]
        public string CheckStatus { set; get; }

        [JsonProperty("reason")]
        public string Reason { set; get; }

        [JsonProperty("lang")]
        public string Lang { set; get; }

        [JsonProperty("country_code")]
        public string CountryCode { set; get; }
    }
}