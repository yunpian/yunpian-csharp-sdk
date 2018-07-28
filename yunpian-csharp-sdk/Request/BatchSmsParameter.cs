using System;
using System.Collections.Generic;
using System.Text;

namespace Yunpian.Sdk.Request
{
    /// <summary>
    /// 单挑短信参数
    /// </summary>
    public class BatchSmsParameter : BaseParameter
    {
        /// <summary>
        /// 接收的手机号，仅支持单号码发送
        /// </summary>
        public ICollection<string> Mobile { get; set; }

        /// <summary>
        /// 已审核短信模板
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 下发号码扩展号，纯数字
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 该条短信在您业务系统内的ID，如订单号或者短信发送记录流水号。默认不开放，如有需要请联系客服申请。
        /// </summary>
        public string UId { get; set; }

        /// <summary>
        /// [callback_url]短信发送后将向这个地址推送(运营商返回的)发送报告。 如推送地址固定，建议在"数据推送与获取”做批量设置。 如后台已设置地址，且请求内也包含此参数，将以请求内地址为准
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 是否为注册验证码短信，如果传入true，则该条短信作为注册验证码短信统计注册成功率，需联系客服开通。
        /// </summary>
        public bool? Register { get; set; }

        /// <summary>
        /// [mobile_stat]若短信中包含云片短链接，此参数传入true将会把短链接替换为目标手机号的专属链接，用于统计哪些号码的机主点击了短信中的链接，可在云片后台查看。详情参考短信点击统计。
        /// </summary>
        public bool? MobileState { get; set; }

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
            _dic["text"] = Text;
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
            if (!string.IsNullOrEmpty(CallbackUrl))
            {
                _dic["callback_url"] = CallbackUrl;
            }
            else
            {
                _dic.Remove("callback_url");
            }
            if (Register != null)
            {
                _dic["register"] = Register.ToString().ToLowerInvariant();
            }
            else
            {
                _dic.Remove("register");
            }
            if (MobileState != null)
            {
                _dic["mobile_stat"] = Mobile.ToString().ToLowerInvariant();
            }
            else
            {
                _dic.Remove("mobile_stat");
            }

        }
    }
}
