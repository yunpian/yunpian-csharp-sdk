using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yunpian.Sdk.Util;

namespace Yunpian.Sdk.Test.Util
{
    [TestClass]
    [Ignore]
    public class TestApiUtil
    {
        [TestMethod]
        public void TestUrlEncodeAndLink()
        {
            Console.WriteLine(ApiUtil.UrlEncodeAndLink("utf-8", ".", "dai,", "zhong"));
            Console.WriteLine(string.Join(".", HttpUtility.UrlEncode("dai,"), HttpUtility.UrlEncode("zhong")));
        }
    }
}