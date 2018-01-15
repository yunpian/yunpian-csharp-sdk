using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class Sign
    {
        [JsonProperty("apply_state")]
        public string ApplyState { get; set; }


        [JsonProperty("sign")]
        public string SignName { get; set; }

        [JsonProperty("is_apply_vip")]
        public bool IsApplyVip { get; set; }


        [JsonProperty("is_only_global")]
        public bool IsOnlyGlobal { get; set; }


        [JsonProperty("industry_type")]
        public string IndustryType { get; set; }

        [JsonProperty("chan")]
        public string Chan { get; set; }


        [JsonProperty("check_status")]
        public string CheckStatus { get; set; }


        [JsonProperty("enabled")]
        public bool Enabled { get; set; }


        [JsonProperty("extend")]
        public string Extend { get; set; }


        [JsonProperty("only_global")]
        public bool OnlyGlobal { get; set; }


        [JsonProperty("remark")]
        public string Remark { get; set; }


        [JsonProperty("vip")]
        public bool Vip { get; set; }
    }
}