using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Yunpian.Sdk.Model
{
    public class VideoLayout
    {
        [DefaultValue("0.0.1")] //TODO default value
        [JsonProperty(PropertyName = "vlVersion", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string VlVersion { set; get; }

        [JsonProperty("subject")]
        public string Subject { set; get; }

        [JsonProperty("frames")]
        public List<VideoFrame> Frames { set; get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class VideoFrame
    {
        [JsonProperty("index")]
        public int Index { set; get; }

        [DefaultValue(1)]
        [JsonProperty(PropertyName = "playTimes", DefaultValueHandling = DefaultValueHandling.Populate)]
        public int PlayTimes { set; get; }

        [JsonProperty("attachments")]
        public List<FrameData> Attachments { set; get; }
    }

    public class FrameData
    {
        [JsonProperty("index")]
        public int Index { set; get; }

        [JsonProperty("fileName")]
        public string FileName { set; get; } // zip里的文件名，如file1.txt。模板创建后改为 文件id.后缀 根据这个字段获取文件
    }
}