using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Yunpian.Sdk.ApiScopes
{
    public class ApiScopeOptions
    {
        public ApiScopeOptions(HttpClient client,YunpianOptions options)
        {
            Client = client;
            Options = options;
        }
        /// <summary>
        /// 用来跟API交互的 <see cref="HttpClient"/>
        /// </summary>
        public HttpClient  Client { get; }

        /// <summary>
        /// 云片的配置
        /// </summary>
        public YunpianOptions Options { get; }

        /// <summary>
        /// APIKey ，此值保存在 <see cref="Options"/>中
        /// </summary>
        public string ApiKey => Options?.ApiKey;
    }
}
