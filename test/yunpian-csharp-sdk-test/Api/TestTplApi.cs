using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestTplApi : TestYunpianApi
    {
        [TestMethod]
        public void TestAdd()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplContent] = "【云片网】您的验证码是#code#11"
            };

            var r = Clnt.Tpl().Add(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestGet()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplId] = "1828927"
            };

            var r = Clnt.Tpl().Get(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestDel()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplId] = "1828927"
            };

            var r = Clnt.Tpl().Del(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestGetDefault()
        {
            var param = new Dictionary<string, string>();

            var r = Clnt.Tpl().GetDefault(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplId] = "1828929",
                [Const.TplContent] = "【云片网】您的验证码是#code#111"
            };

            var r = Clnt.Tpl().Update(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestAddVoiceNotify()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplContent] = "应用#name#在#time#无法响应"
            };

            var r = Clnt.Tpl().AddVoiceNotify(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestUpdateVoiceNotify()
        {
            var param = new Dictionary<string, string>
            {
                [Const.TplId] = "1828931",
                [Const.TplContent] = "应用#name#在#time#无法响应11"
            };

            var r = Clnt.Tpl().UpdateVoiceNotify(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}