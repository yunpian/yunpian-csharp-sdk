using System.Collections.Generic;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk
{
    public class YunpianConf
    {
        private readonly Dictionary<string, string> _conf;

        private string _withApi;
        private Dictionary<string, string> _withProps;


        public YunpianConf()
        {
            _conf = new Dictionary<string, string>
            {
                // online config
                //{Const.YP_APIKEY,""},
                {Const.YpVersion, Const.VersionV2},
                {Const.YpUserHost, "https://sms.yunpian.com"},
                {Const.YpSignHost, "https://sms.yunpian.com"},
                {Const.YpTplHost, "https://sms.yunpian.com"},
                {Const.YpSmsHost, "https://sms.yunpian.com"},
                {Const.YpVoiceHost, "https://voice.yunpian.com"},
                {Const.YpFlowHost, "https://flow.yunpian.com"},
                {Const.YpShortUrlHost, "https://sms.yunpian.com"},
                {Const.YpVideoSmsHost, "https://vsms.yunpian.com"},

                // http TODO
                {Const.HttpCharset, "utf-8"},
                {Const.HttpSoTimeout, "30"} //second
            };
        }

        public YunpianConf With(string apikey)
        {
            _withApi = apikey;
            return this;
        }

        public YunpianConf With(Dictionary<string, string> props)
        {
            _withProps = props;
            return this;
        }

        /// <summary>
        ///     Build this instance.
        /// </summary>
        /// <returns>The build.</returns>
        public YunpianConf Build()
        {
            try
            {
                // load props
                if (_withProps != null)
                    foreach (var p in _withProps)
                        _conf[p.Key] = p.Value;

                // load apikey
                if (_withApi != null) _conf[Const.YpApikey] = _withApi;
            }
            finally
            {
                _withApi = null;
                _withProps = null;
            }

            return this;
        }

        public string Apikey()
        {
            return _conf[Const.YpApikey];
        }

        public string Get(string key, string defval)
        {
            return _conf.ContainsKey(key) ? _conf[key] : defval;
        }

        public int GetInt(string key, string defval)
        {
            return int.Parse(Get(key, defval));
        }

        public long GetLong(string key, string defval)
        {
            return long.Parse(Get(key, defval));
        }

        public override string ToString()
        {
            return string.Format("[YunpianConf]-{0}", Apikey());
        }
    }
}