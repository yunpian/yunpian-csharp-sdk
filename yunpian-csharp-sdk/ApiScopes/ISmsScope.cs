using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yunpian.Sdk.Model;
using Yunpian.Sdk.Request;

namespace Yunpian.Sdk.ApiScopes
{
    public interface ISmsScope : IApiScope
    {
        /// <summary>
        /// 单条短信发送
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <exception cref="SmsException">短信发送失败后的异常，通常为<see cref="SmsSingleSend.Code"/>不正常导致</exception>
        /// <returns></returns>
        Task<SmsSingleSend> SendSingleSmsAsync(SingleSmsParameter parameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<SmsBatchSend> SendBatchSmsAsync(BatchSmsParameter parameter);
    }
}
