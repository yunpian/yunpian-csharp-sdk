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
        /// <para>如果返回的结果不是正确的结果将thow <see cref="SmsException"/></para>
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <exception cref="SmsException">短信发送失败后的异常，通常为<see cref="SmsSingleSend.Code"/>不正常导致</exception>
        /// <returns>短信发送结果</returns>
        Task<SmsSingleSend> SendSingleSmsAsync(SingleSmsParameter parameter);

        /// <summary>
        /// 批量发送短信
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>短信发送结果</returns>
        Task<SmsBatchSend> SendBatchSmsAsync(BatchSmsParameter parameter);

        /// <summary>
        /// 指定模板发送单条短信
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        Task<SmsSingleSend> TmplSingleSmsSendAsync(TmplSingleSmsParameter parameter);

        /// <summary>
        /// 指定模板批量发送短信
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        Task<SmsBatchSend> TmplBatchSmsSendAsync(TmplBatchSmsParameter parameter);


    }
}
