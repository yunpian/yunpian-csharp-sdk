using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestVoiceApi : TestYunpianApi
    {
        [TestMethod]
        public void TestSend()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.Code] = "123456"
            };

            var r = Clnt.Voice().Send(param);

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

            var r = Clnt.Voice().PullStatus(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestTplNotify()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Mobile] = "18616020610",
                [Const.TplId] = "3373",
                [Const.TplValue] = "name=dzh&time=7"
            };

            var r = Clnt.Voice().TplNotify(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}