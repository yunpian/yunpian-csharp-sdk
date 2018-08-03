using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yunpian.Sdk.ApiScopes;

namespace Yunpian.Sdk
{
    public class ConnectionFactory
    {
        private static HttpClient _defaultClient = new HttpClient();// static
        private readonly YunpianOptions _options;
        private readonly HttpClient _client;

        static ConnectionFactory()
        {
            _defaultClient.Timeout = TimeSpan.FromSeconds(30);
            _defaultClient.DefaultRequestHeaders.Add("Api-Lang", "csharp");
        }

        /// <summary>
        /// 初始化<see cref="ConnectionFactory"/>
        /// </summary>
        /// <param name="options">云片的配置选项</param>
        public ConnectionFactory(YunpianOptions options):this(options,_defaultClient)
        {
        }

        /// <summary>
        /// 初始化<see cref="ConnectionFactory"/>
        /// </summary>
        /// <param name="options">云片的配置选项</param>
        /// <param name="client">将被用来跟云片交互的 <see cref="HttpClient"/> </param>
        public ConnectionFactory(YunpianOptions options,HttpClient client)
        {
            _options = options;
            _client = client;
        }

        public T CreateScope<T>(Func<ApiScopeOptions,T> scopeCreator) where T : IApiScope
        {
            var options = CreateApiScopteOptions();
            return scopeCreator(options);
        }
        public async Task<T> CreateScopeAsync<T>(Func<ApiScopeOptions, Task<T>> scopeCreator) where T : IApiScope
        {
            var options = CreateApiScopteOptions();
            return await scopeCreator(options);
        }

        private ApiScopeOptions CreateApiScopteOptions()
        {
            return new ApiScopeOptions(_client, _options);
        }
    }
}
