using System;
using System.Collections.Generic;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Api
{
    public class UserApi : YunpianApi
    {
        public const string ApiName = "user";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpUserHost, "https://sms.yunpian.com");
        }

        /**
         * <h1>查账户信息</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * 
         * @return
         */
        public Result<User> Get()
        {
            var r = new Result<User>();
            var param = new Dictionary<string, string>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<User>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp[Const.User].ToObject<User>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<User>();
                    }
                }

                return null;
            });

            try
            {
                Path = "get.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>修改账户信息</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * emergency_contact String 否 紧急联系人 zhangshan
         * </p>
         * <p>
         * emergency_mobile String 否 紧急联系人手机号 13012345678
         * </p>
         * <p>
         * alarm_balance Long 否 短信余额提醒阈值。 一天只提示一次 100
         * </p>
         * 
         * @param param
         *            emergency_contact emergency_mobile alarm_balance
         * @return
         */
        public Result<User> Set(Dictionary<string, string> param)
        {
            var r = new Result<User>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<User>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<User>();
                    }
                }

                return null;
            });

            try
            {
                Path = "set.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }
    }
}