using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestVideoSmsApi : TestYunpianApi
    {
        [TestMethod]
        public void TestGetTpl()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplId] = "117"
            };

            var r = Clnt.VideoSms().GetTpl(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestTplBatchSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplId] = "1",
                [Const.Mobile] = "18616020610,18616020611"
            };

            var r = Clnt.VideoSms().TplBatchSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestAddTpl()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Sign] = "【企盆阔记】"
            };

            var vl = new VideoLayout {Subject = "restapi-" + new DateTime().Millisecond, VlVersion = "0.0.1"};

            var frame1 = new VideoFrame {Index = 1};
            var data1 = new FrameData
            {
                Index = 1,
                FileName = "data1.txt"
            };
            var data2 = new FrameData
            {
                Index = 2,
                FileName = "data2.mp4"
            };
            frame1.Attachments = new List<FrameData> {data1, data2};

            vl.Frames = new List<VideoFrame> {frame1};

            var fs = new FileStream("/Users/dzh/temp/vsms/Archive.zip", FileMode.Open);
            var material = new byte[fs.Length];
            fs.Read(material, 0, material.Length);
            fs.Close();

            var layout = vl.ToString();
            Console.WriteLine(layout);
            var r = Clnt.VideoSms().AddTpl(param, layout, material);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}