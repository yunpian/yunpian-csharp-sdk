using System;
using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class User
    {
        [JsonProperty("nick")]
        public string Nick { set; get; }

        [JsonProperty("gmt_created")]
        public DateTime GmtCreated { set; get; }

        [JsonProperty("mobile")]
        public string Mobile { set; get; }

        [JsonProperty("email")]
        public string Email { set; get; }

        [JsonProperty("ip_white_list")]
        public string IpWhiteList { set; get; }

        [JsonProperty("api_version")]
        public string ApiVersion { set; get; }

        [JsonProperty("alarm_balance")]
        public long AlarmBalance { set; get; }

        [JsonProperty("emergency_content")]
        public string EmergencyContent { set; get; }

        [JsonProperty("emerygency_mobile")]
        public string EmerygencyMobile { set; get; }

        [JsonProperty("balance")]
        public double Balance { set; get; }
    }
}