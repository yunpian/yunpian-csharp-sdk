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
        public ConnectionFactory(YunpianOptions options):this(options,_defaultClient)
        {
        }

        public ConnectionFactory(YunpianOptions options,HttpClient client)
        {
            _options = options;
            _client = client;
        }

        public T CreateScope<T>(Func<YunpianOptions,HttpClient,T> scopeCreator) where T : IApiScope
        {
            return scopeCreator(_options, _client);
        }
        public async Task<T> CreateScopeAsync<T>(Func<YunpianOptions, HttpClient, Task<T>> scopeCreator) where T : IApiScope
        {
            return await scopeCreator(_options,_client);
        }
    }
}
