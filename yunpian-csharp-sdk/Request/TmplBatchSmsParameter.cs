using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Yunpian.Sdk.Request
{
    /// <summary>
    /// 批量（多条）短信参数
    /// </summary>
    public class TmplBatchSmsParameter : BaseParameter
    {
        /// <summary>
        /// 接收的手机号，仅支持单号码发送
        /// </summary>
        public ICollection<string> Mobile { get; set; } = new List<string>();

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
            if(Mobile.Count > 1000)
            {
                throw new IndexOutOfRangeException($"{nameof(Mobile)}的个数不能超过1000个");
            }
            _dic["mobile"] = string.Join(",",Mobile);
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
