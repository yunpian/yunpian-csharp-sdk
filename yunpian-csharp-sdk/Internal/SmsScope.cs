using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yunpian.Sdk.ApiScopes;
using Yunpian.Sdk.Model;
using Yunpian.Sdk.Request;
using Yunpian.Sdk.Util;

namespace Yunpian.Sdk.Internal
{
    internal class SmsScope : ISmsScope
    {
        public ApiScopeOptions Options { get; }

        private HttpClient Client => Options?.Client;

        public Uri UriBase { get; }

        public SmsScope(ApiScopeOptions option)
        {
            Options = option ?? throw new ArgumentNullException(nameof(option));
        }

        /// <inheritDoc />
        public async Task<SmsSingleSend> SendSingleSmsAsync(SingleSmsParameter parameter)
        {
            var defautDic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["apikey"] = Options.ApiKey
            };
            var apiUrl = "https://sms.yunpian.com/v2/sms/single_send.json";
            var resultDic = DictonaryHelper.Combin(defautDic, parameter.ToDictionary(), StringComparer.OrdinalIgnoreCase);

            var response = await Client.PostAsync(apiUrl, new FormUrlEncodedContent(resultDic));

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<SmsSingleSend>(json);
            if (model.Code != 0)
            {
                throw new SmsException(model.Msg, json);
            }
            return model;

        }

        /// <inheritDoc />
        public async Task<SmsBatchSend> SendBatchSmsAsync(BatchSmsParameter parameter)
        {
            var defautDic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["apikey"] = Options.ApiKey
            };
            var apiUrl = "https://sms.yunpian.com/v2/sms/batch_send.json";
            var resultDic = DictonaryHelper.Combin(defautDic, parameter.ToDictionary(), StringComparer.OrdinalIgnoreCase);

            var response = await Client.PostAsync(apiUrl, new FormUrlEncodedContent(resultDic));

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<SmsBatchSend>(json);

            return model;
        }

        /// <inheritDoc />
        public async Task<SmsSingleSend> TmplSingleSmsSendAsync(TmplSingleSmsParameter parameter)
        {
            var defautDic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["apikey"] = Options.ApiKey
            };
            var apiUrl = "https://sms.yunpian.com/v2/sms/tpl_single_send.json";
            var resultDic = DictonaryHelper.Combin(defautDic, parameter.ToDictionary(), StringComparer.OrdinalIgnoreCase);

            var response = await Client.PostAsync(apiUrl, new FormUrlEncodedContent(resultDic));

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<SmsSingleSend>(json);

            return model;
        }

        /// <inheritDoc />
        public async Task<SmsBatchSend> TmplBatchSmsSendAsync(TmplBatchSmsParameter parameter)
        {
            var defautDic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["apikey"] = Options.ApiKey
            };
            var apiUrl = "https://sms.yunpian.com/v2/sms/tpl_batch_send.json";
            var resultDic = DictonaryHelper.Combin(defautDic, parameter.ToDictionary(), StringComparer.OrdinalIgnoreCase);

            var response = await Client.PostAsync(apiUrl, new FormUrlEncodedContent(resultDic));

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<SmsBatchSend>(json);

            return model;
        }
    }
}
