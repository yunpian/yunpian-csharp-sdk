using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class SmsSingleSend
    {
        /// <summary>
        /// 状态码，0代表发送成功，其他code代表出错，详细见"返回值说明"页面
        /// </summary>
        [JsonProperty("code")]
        public int Code { set; get; }

        /// <summary>
        /// 例如""发送成功""，或者相应错误信息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { set; get; }

        /// <summary>
        /// 发送成功短信的计费条数(计费条数：70个字一条，超出70个字时按每67字一条计费)
        /// </summary>
        [JsonProperty("count")]
        public int Count { set; get; }

        /// <summary>
        /// 扣费金额，单位：元，类型：双精度浮点型/double
        /// </summary>
        [JsonProperty("fee")]
        public double Fee { set; get; }

        /// <summary>
        /// 计费单位；例如：“RMB”
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { set; get; }

        /// <summary>
        /// 发送手机号
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { set; get; }

        /// <summary>
        /// 短信id，64位整型， 对应Java和C#的long，不可用int解析
        /// </summary>
        [JsonProperty("sid")]
        public long Sid { set; get; }
    }
}