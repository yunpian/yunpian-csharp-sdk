using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    [TestClass]
    [Ignore]
    public class TestUserApi : TestYunpianApi
    {
        [TestMethod]
        public void TestGet()
        {
            var r = Clnt.User().Get();

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }

        [TestMethod]
        public void TestSet()
        {
            var param = new Dictionary<string, string>
            {
                [Const.EmergencyContact] = "dzh",
                [Const.EmergencyMobile] = "18616020610",
                [Const.AlarmBalance] = "10"
            };

            var r = Clnt.User().Set(param);

            Console.WriteLine(r);
            Console.WriteLine(r.E);
        }
    }
}