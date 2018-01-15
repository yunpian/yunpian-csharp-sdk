using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class Result<T>
    {
        [JsonProperty("code")]
        [DefaultValue(Const.Ok)]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("e")]
        [JsonIgnore]
        public Exception E { get; set; }

        public bool IsSucc()
        {
            return Code == Const.Ok;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}