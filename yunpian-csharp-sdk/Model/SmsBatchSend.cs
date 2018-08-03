using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class SmsBatchSend
    {
        /// <summary>
        /// 扣费条数，70个字一条，超出70个字时按每67字一条计
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { set; get; }

        /// <summary>
        /// 扣费金额，单位：元，类型：双精度浮点型/double
        /// </summary>
        [JsonProperty("total_fee")]
        public double TotalFee { set; get; }

        /// <summary>
        /// 计费单位；例如：“RMB”
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { set; get; }

        /// <summary>
        /// 每条短信的状态
        /// </summary>
        [JsonProperty("data")]
        public List<SmsSingleSend> Data { set; get; }
    }
}