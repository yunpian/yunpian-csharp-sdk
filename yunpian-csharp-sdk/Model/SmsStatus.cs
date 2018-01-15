using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class BaseStatus
    {
        [JsonProperty("sid")]
        public string Sid { set; get; }

        [JsonProperty("mobile")]
        public string Mobile { set; get; }

        [JsonProperty("report_status")]
        public string ReportStatus { set; get; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { set; get; }

        [JsonProperty("user_receive_time")]
        public string UserReceiveTime { set; get; }
    }

    public class SmsStatus : BaseStatus
    {
        [JsonProperty("uid")]
        public string Uid { set; get; }
    }
}