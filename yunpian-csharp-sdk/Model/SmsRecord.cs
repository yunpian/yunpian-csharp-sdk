using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class SmsRecord
    {
        [JsonProperty("sid")]
        public string Sid { set; get; }

        [JsonProperty("mobile")]
        public string Mobile { set; get; }

        [JsonProperty("send_time")]
        public string SendTime { set; get; }

        [JsonProperty("text")]
        public string Text { set; get; }

        [JsonProperty("report_status")]
        public string ReportStatus { set; get; }

        [JsonProperty("fee")]
        public double Fee { set; get; }

        [JsonProperty("user_receive_time")]
        public string UserReceiveTime { set; get; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { set; get; }

        [JsonProperty("uid")]
        public string Uid { set; get; }
    }
}