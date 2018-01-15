using System.Collections.Generic;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Test.Api
{
    public class TestYunpianApi
    {
        private const string TestApikey = "";

        private static readonly Dictionary<string, string> TestDev = new Dictionary<string, string>
        {
            {Const.YpVersion, Const.VersionV2},
            {Const.YpUserHost, "https://test-api.yunpian.com"},
            {Const.YpSignHost, "https://test-api.yunpian.com"},
            {Const.YpTplHost, "https://test-api.yunpian.com"},
            {Const.YpSmsHost, "https://test-api.yunpian.com"},
            {Const.YpVoiceHost, "https://test-api.yunpian.com"},
            {Const.YpFlowHost, "https://test-api.yunpian.com"},
            {Const.YpShortUrlHost, "https://test-api.yunpian.com"},
            {Const.YpVideoSmsHost, "https://test-api.yunpian.com"},
            {Const.HttpCharset, "utf-8"},
            {Const.HttpSoTimeout, "30"} //second
        };

        protected static YunpianClient Clnt;

        protected TestYunpianApi()
        {
            //Console.WriteLine(TestApikey);
            //Clnt = new YunpianClient(TestApikey, TestDev).Init(); // dev
            Clnt = new YunpianClient(TestApikey).Init(); // online
        }

        ~TestYunpianApi()
        {
            Clnt.Dispose();
        }
    }
}