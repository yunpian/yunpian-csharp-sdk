using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test
{
    [TestClass]
    [Ignore]
    public class JsonTest
    {
        [ClassInitialize]
        public static void Init(TestContext c)
        {
        }

        [ClassCleanup]
        public static void Down()
        {
        }

        [TestMethod]
        public void TestToJson()
        {
            var r = new Result<string>
            {
                Code = 1,
                Msg = "2",
                Detail = "3",
                Data = "4"
            };
            var json = JsonConvert.SerializeObject(r);
            Console.WriteLine(json);

            r = JsonConvert.DeserializeObject<Result<string>>(json);
            Assert.IsTrue(r.Code == 1);
        }

        [TestMethod]
        public void TestFromJson()
        {
            const string json = "{\"code\":1, \"msg\":\"2\", \"detail\":\"3\", \"data\":\"4\", \"e\":null}";
            var r = JsonConvert.DeserializeObject<Result<string>>(json);
            r.Code = 2;
            Console.WriteLine(r);
            Assert.IsTrue(r.Code == 2);
        }
    }
}