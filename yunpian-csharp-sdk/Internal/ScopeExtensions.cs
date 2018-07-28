using System;
using System.Collections.Generic;
using System.Text;
using Yunpian.Sdk.ApiScopes;
using Yunpian.Sdk.Internal;

namespace Yunpian.Sdk
{
    public static class ScopeExtensions
    {
        /// <summary>
        /// 创建<see cref="ISmsScope"/>
        /// </summary>
        /// <param name="factory">要扩展的<see cref="ConnectionFactory"/>实例</param>
        /// <returns></returns>
        public static ISmsScope CreateSmsScope(this ConnectionFactory factory)
        {
            return factory.CreateScope((option, client) => new SmsScope(option,client));
        }
    }
}
