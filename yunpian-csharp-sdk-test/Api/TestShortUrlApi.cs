using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestShortUrlApi : TestYunpianApi
    {
        [TestMethod]
        public void TestShorten()
        {
            var param = new Dictionary<string, string>
            {
                [Const.LongUrl] = "https://www.yunpian.com/",
                [Const.Name] = "sdk-test1",
                [Const.StatDuration] = "3",
                [Const.Provider] = "1"
            };

            var r = Clnt.ShortUrl().Shorten(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestStat()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Sid] = "ckAclC",
                [Const.StartTime] = "2017-09-29 11:00:00",
                [Const.StatDuration] = "3",
                [Const.Provider] = "1"
            };

            var r = Clnt.ShortUrl().Stat(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}