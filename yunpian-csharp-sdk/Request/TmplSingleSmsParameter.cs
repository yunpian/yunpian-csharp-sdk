using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Yunpian.Sdk.Request
{
    /// <summary>
    /// 单挑短信参数
    /// </summary>
    public class TmplSingleSmsParameter : BaseParameter
    {
        /// <summary>
        /// 接收的手机号，仅支持单号码发送
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// tpl_id 模板Id
        /// </summary>
        public string TmplId { get; set; }

        /// <summary>
        /// tpl_value 变量名和变量值对。key 和 vale 无需encode
        /// </summary>
        public IDictionary<string, string> TmplValues { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 下发号码扩展号，纯数字
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 该条短信在您业务系统内的ID，如订单号或者短信发送记录流水号。默认不开放，如有需要请联系客服申请。
        /// </summary>
        public string UId { get; set; }


        /// <summary>
        /// 实现写入字典功能
        /// </summary>
        protected override void FlushToDic()
        {
            _dic["mobile"] = Mobile;
            _dic["tpl_id"] = TmplId;

            var tplValue = string.Join("&", TmplValues.OrderBy(x => x.Key)
                .Select(x => {
                    // 处理 不带 # 号
                    var key = x.Key;
                    if (!key.StartsWith("#") && !key.EndsWith("#"))
                    {
                        key = $"#{key}#";
                    }
                    return new KeyValuePair<string, string>(key, x.Value);
                })
                .Select(x => $"{WebUtility.UrlEncode(x.Key)}={WebUtility.UrlEncode(x.Value ?? string.Empty)}"));
            _dic["tpl_value"] = tplValue;

            if (!string.IsNullOrEmpty(Extend))
            {
                _dic["extend"] = Extend;
            }
            else
            {
                _dic.Remove("extend");
            }

            if (!string.IsNullOrEmpty(UId))
            {
                _dic["uid"] = UId;
            }
            else
            {
                _dic.Remove("uid");
            }

        }
    }
}
