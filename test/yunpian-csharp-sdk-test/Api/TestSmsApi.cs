using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;
using Yunpian.Sdk.Util;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestSmsApi : TestYunpianApi
    {
        [TestMethod]
        public void TestSingleSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.Text] = "【云片网】您的验证码是1234"
            };

            var r = Clnt.Sms().SingleSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestBatchSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020613,18616020614",
                [Const.Text] = "【云片网】您的验证码是1234"
            };

            var r = Clnt.Sms().BatchSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestMultiSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610,18616020611",
                [Const.Text] = ApiUtil.UrlEncodeAndLink("utf-8", ",", "【哈哈哈】您的验证码,是1234", "【哈哈哈】您的验证码是1111")
            };

            var r = Clnt.Sms().MultiSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestTplSingleSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.TplId] = "1",
                [Const.TplValue] = "#company#=云片"
            };

            var r = Clnt.Sms().TplSingleSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestTplBatchSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.TplId] = "1",
                [Const.TplValue] = "#company#=云片"
            };

            var r = Clnt.Sms().TplBatchSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestPullStatus()
        {
            var param = new Dictionary<string, string>
            {
                [Const.PageSize] = "20"
            };

            var r = Clnt.Sms().PullStatus(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestPullReply()
        {
            var param = new Dictionary<string, string>
            {
                [Const.PageSize] = "20"
            };

            var r = Clnt.Sms().PullReply(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestGetRecord()
        {
            var param = new Dictionary<string, string>
            {
                [Const.StartTime] = "2013-08-11 00:00:00",
                [Const.EndTime] = "2016-12-05 00:00:00",
                [Const.PageNum] = "1",
                [Const.PageSize] = "20"
            };

            var r = Clnt.Sms().GetRecord(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);

            // v1
            var sms = Clnt.Sms();
            sms.Version = Const.VersionV1;
            r = sms.GetRecord(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestGetBlackWord()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Text] = "高利贷,发票"
            };

            var r = Clnt.Sms().GetBlackWord(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);

            // v1
            var sms = Clnt.Sms();
            sms.Version = Const.VersionV1;
            r = sms.GetBlackWord(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.Text] = "【云片网】您的验证码是1234"
            };

            var r = Clnt.Sms().Send(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestGetReply()
        {
            var param = new Dictionary<string, string>
            {
                [Const.StartTime] = "2013-08-11 00:00:00",
                [Const.EndTime] = "2016-12-05 00:00:00",
                [Const.PageNum] = "1",
                [Const.PageSize] = "20"
            };

            var r = Clnt.Sms().GetReply(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestTplSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020611",
                [Const.TplId] = "1",
                [Const.TplValue] = "#company#=云片网"
            };

            var r = Clnt.Sms().TplSend(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestCount()
        {
            var param = new Dictionary<string, string>
            {
                [Const.StartTime] = "2013-08-11 00:00:00",
                [Const.EndTime] = "2016-12-05 00:00:00",
                [Const.PageNum] = "1",
                [Const.PageSize] = "20"
            };

            var r = Clnt.Sms().Count(param);
            Console.WriteLine(r);
            Console.WriteLine(r.E);

            // v1
            var sms = Clnt.Sms();
            sms.Version = Const.VersionV1;
            r = sms.Count(param);
            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestRegComplete()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.Time] = "2016-12-05 00:00:00"
            };

            var r = Clnt.Sms().RegComplete(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}