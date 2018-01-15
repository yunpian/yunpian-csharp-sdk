using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class SmsBatchSend
    {
        [JsonProperty("total_count")]
        public int TotalCount { set; get; }

        [JsonProperty("total_fee")]
        public double TotalFee { set; get; }

        [JsonProperty("unit")]
        public string Unit { set; get; }

        [JsonProperty("data")]
        public List<SmsSingleSend> Data { set; get; }
    }
}