using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class VoiceStatus : BaseStatus
    {
        [JsonProperty("uid")]
        public string Uid { set; get; }

        [JsonProperty("duration")]
        public double Duration { set; get; }
    }
}