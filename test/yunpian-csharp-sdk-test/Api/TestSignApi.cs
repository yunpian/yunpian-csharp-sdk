using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestSignApi : TestYunpianApi
    {
        [TestMethod]
        public void TestAdd()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Sign] = "你好吗你好",
                [Const.Notify] = "true",
                [Const.Applyvip] = "false",
                [Const.Isonlyglobal] = "false",
                [Const.Industrytype] = "其它",
                [Const.LicenseUrl] = "https://www.yunpian.com/"
            };

            var r = Clnt.Sign().Add(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Sign] = "你好吗",
                [Const.OldSign] = "我我我",
                [Const.Notify] = "true",
                [Const.Applyvip] = "false",
                [Const.Isonlyglobal] = "false",
                [Const.Industrytype] = "其它",
                [Const.LicenseUrl] = "https://www.yunpian.com/"
            };

            var r = Clnt.Sign().Update(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestGet()
        {
            var param = new Dictionary<string, string>
            {
                [Const.Sign] = "你好吗",
                [Const.PageNum] = "1",
                [Const.PageSize] = "2"
            };

            var r = Clnt.Sign().Get(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}