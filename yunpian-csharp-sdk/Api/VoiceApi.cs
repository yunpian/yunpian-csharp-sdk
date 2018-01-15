using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Api
{
    public class VoiceApi : YunpianApi
    {
        public const string ApiName = "voice";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpVoiceHost, "https://voice.yunpian.com");
        }

        /**
         * <h1>发语音验证码</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是 接收的手机号、固话（需加区号） 15205201314 01088880000
         * </p>
         * <p>
         * code String 是 验证码，支持4~6位阿拉伯数字 1234
         * </p>
         * <p>
         * encrypt String 否 加密方式 使用加密 tea (不再使用)
         * </p>
         * <p>
         * _sign String 否 签名字段 参考使用加密 393d079e0a00912335adfe46f4a2e10f (不再使用)
         * </p>
         * <p>
         * callback_url String 否 本条语音验证码状态报告推送地址 http://your_receive_url_address
         * </p>
         * <p>
         * display_num String 否 透传号码，为保证全国范围的呼通率，云片会自动选择最佳的线路，透传的主叫号码也会相应变化。
         * 如需透传固定号码则需要单独注册报备，为了确保号码真实有效，客服将要求您使用报备的号码拨打一次客服电话
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<VoiceSend> Send(Dictionary<string, string> param)
        {
            var r = new Result<VoiceSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.Code);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<VoiceSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp[Const.Result].ToObject<VoiceSend>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<VoiceSend>();
                    }
                }

                return null;
            });

            try
            {
                Path = "send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>发送语音通知</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * mobile String 是 接收的手机号、固话（需加区号） 15205201314 01088880000
         * </p>
         * <p>
         * tpl_id Long 是 审核通过的模版ID 1136
         * </p>
         * <p>
         * tpl_value String 是 模版的变量值
         * 如模版内容&quot;课程#name#在#time#开始&quot;,那么这里的值为&quot;name=计算机&amp;time=17点&quot;,注意若出现特殊字符(如&#39;=&#39;,&#39;&amp;&#39;)则需要URLEncode内容
         * </p>
         * <p>
         * callback_url String 否 本条语音验证码状态报告推送地址 http://your_receive_url_address
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<VoiceSend> TplNotify(Dictionary<string, string> param)
        {
            var r = new Result<VoiceSend>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Mobile, Const.TplId, Const.TplValue);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<VoiceSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<VoiceSend>();
                    }
                }

                return null;
            });

            try
            {
                Path = "tpl_notify.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>获取状态报告</h1>
         * 
         * <p>
         * 参数名 是否必须 描述 示例
         * </p>
         * <p>
         * apikey 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * page_size 否 每页个数，最大100个，默认20个 20
         * </p>
         * <p>
         * type Integer 否 拉取类型，1-语音验证码 2-语音通知，默认type=1 1
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<List<VoiceStatus>> PullStatus(Dictionary<string, string> param)
        {
            var r = new Result<List<VoiceStatus>>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<VoiceStatus>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp is JObject o
                            ? o[Const.VoiceStatus].ToObject<List<VoiceStatus>>()
                            : new List<VoiceStatus>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<List<VoiceStatus>>();
                    }
                    default: return new List<VoiceStatus>();
                }
            });

            try
            {
                Path = "pull_status.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }
    }
}