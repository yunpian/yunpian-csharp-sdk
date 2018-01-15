using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yunpian.Sdk.Api;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk
{
    /// <inheritdoc />
    /// <summary>
    ///     Yunpian client.
    ///     For example:
    ///     YunpianClient clnt = new YunpianClient("apikey").init();
    ///     Result r = clnt.Sms().SingleSend(...);
    ///     if(r.IsSucc())
    ///     {
    ///     // handle r.Data
    ///     }
    ///     else
    ///     {
    ///     // other errors or exception
    ///     }
    ///     ....
    ///     clnt.Dispose(); // Before Application will exit.
    /// </summary>
    public class YunpianClient : IDisposable
    {
        private readonly YunpianConf _conf;

        private ApiFactory _api;

        private HttpClient _clnt;


        public YunpianClient(string apikey, Dictionary<string, string> props = null)
        {
            _conf = new YunpianConf().With(apikey).With(props).Build();
        }


        public void Dispose()
        {
            _clnt?.Dispose();
        }


        public YunpianClient Init()
        {
            // create httpclient
            _clnt = CreateHttpClient(_conf);
            // create ApiFactory
            _api = new ApiFactory(this);
            return this;
        }

        // new MediaTypeHeaderValue("application/x-www-form-urlencoded;utf-8");

        protected virtual HttpClient CreateHttpClient(YunpianConf conf)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Api-Lang", "csharp");
            httpClient.Timeout = TimeSpan.FromSeconds(conf.GetInt(Const.HttpSoTimeout, "30"));

            return httpClient;
        }

        public async Task<string> Post(string uri, string data, string charset)
        {
            if (charset == null)
                charset = _conf.Get(Const.HttpCharset, Const.HttpCharsetDefault);
            var content = new StringContent(data, Encoding.GetEncoding(charset),
                "application/x-www-form-urlencoded"); //FormUrlEncodedContent
            content.Headers.ContentEncoding.Add(charset);
            using (var message = await _clnt.PostAsync(uri, content))
            {
                return await message.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Post(string uri, HttpContent data, string charset)
        {
            if (charset == null)
                charset = _conf.Get(Const.HttpCharset, Const.HttpCharsetDefault);
            data.Headers.ContentEncoding.Add(charset);
            using (var message = await _clnt.PostAsync(uri, data))
            {
                return await message.Content.ReadAsStringAsync();
            }
        }

        public ShortUrlApi ShortUrl()
        {
            return _api.Api<ShortUrlApi>(ShortUrlApi.ApiName);
        }

        public SignApi Sign()
        {
            return _api.Api<SignApi>(SignApi.ApiName);
        }

        public SmsApi Sms()
        {
            return _api.Api<SmsApi>(SmsApi.ApiName);
        }

        public TplApi Tpl()
        {
            return _api.Api<TplApi>(TplApi.ApiName);
        }

        public UserApi User()
        {
            return _api.Api<UserApi>(UserApi.ApiName);
        }

        public VideoSmsApi VideoSms()
        {
            return _api.Api<VideoSmsApi>(VideoSmsApi.ApiName);
        }

        public VoiceApi Voice()
        {
            return _api.Api<VoiceApi>(VoiceApi.ApiName);
        }

        public override string ToString()
        {
            return string.Format("[YunpianClient]-{0}", _conf.Apikey());
        }


        public YunpianConf Conf()
        {
            return _conf;
        }
    }
}