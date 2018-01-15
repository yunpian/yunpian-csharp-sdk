using System;
using System.Collections.Generic;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Api
{
    public class ShortUrlApi : YunpianApi
    {
        public const string ApiName = "short_url";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpShortUrlHost, "https://sms.yunpian.com");
        }

        /**
         * <h1>生成短链接 only v2</h1>
         * <p>
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * long_url String 是 待转换的长网址，必须http://或https://开头 https://www.yunpian.com
         * </p>
         * <p>
         * stat_duration Integer 否 点击量统计持续时间（天），过期后不再统计，区间[0,30]，0表示不统计，默认30 30
         * </p>
         * <p>
         * provider Integer 否 生成的链接的域名，传入1是yp2.cn，2是t.cn，默认1 1
         * </p>
         * <p>
         * name String 否 取名方便区分，默认为“MM-dd HH:mm生成的短链接” yunpian
         * </p>
         *
         * @param param
         * @return
         */
        public Result<ShortUrl> Shorten(Dictionary<string, string> param)
        {
            var r = new Result<ShortUrl>();
            r = CheckParam(ref param, r, Const.Apikey, Const.LongUrl);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<ShortUrl>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                        return rsp[Const.ShortUrl].ToObject<ShortUrl>();
                    default: return null;
                }
            });

            try
            {
                Path = "shorten.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>获取短链接统计 only v2</h1>
         * <p>
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * sid String 是 短链接唯一标识 ckAclC
         * </p>
         * <p>
         * start_time String 否 开始时间，默认一个小时前 2017-03-29 11:30:00
         * </p>
         * <p>
         * end_time String 否 结束时间，默认当前时间 2017-03-29 12:10:00
         * </p>
         *
         * @param param
         * @return
         */
        public Result<Dictionary<string, long>> Stat(Dictionary<string, string> param)
        {
            var r = new Result<Dictionary<string, long>>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Sid);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Dictionary<string, long>>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                        return rsp[Const.Stat].ToObject<Dictionary<string, long>>();
                    default: return null;
                }
            });

            try
            {
                Path = "stat.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }
    }
}