using System;
using System.Collections.Generic;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Api
{
    public class SignApi : YunpianApi
    {
        public const string ApiName = "sign";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpSignHost, "https://sms.yunpian.com");
        }

        /**
         * <h1>添加签名API</h1>
         *
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * sign String 是 签名内容 云片网
         * </p>
         * <p>
         * notify Boolean 否 是否短信通知结果，默认true true
         * </p>
         * <p>
         * apply_vip Boolean 否 是否申请专用通道，默认false false
         * </p>
         * <p>
         * is_only_global Boolean 否 是否仅发国际短信，默认false false
         * </p>
         * <p>
         * industry_type String 否 所属行业，默认“其它” 物联网 其他值例如:1. 游戏 2. 移动应用 3. 视频 4. 教育 5.
         * IT/通信/电子服务 6. 电子商务 7. 金融 8. 网站 9. 商业服务 10. 房地产/建筑 11. 零售/租赁/贸易 12.
         * 生产/加工/制造 13. 交通/物流 14. 文化传媒 15. 能源/电气 16. 政府企业 17. 农业 18. 物联网 19. 其它
         * </p>
         *
         * @param param
         *            sign notify apply_vip is_only_global industry_type
         * @return
         */
        public Result<Sign> Add(Dictionary<string, string> param)
        {
            var r = new Result<Sign>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Sign);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Sign>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                        return rsp[Const.Sign].ToObject<Sign>();
                    default: return null;
                }
            });

            try
            {
                Path = "add.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>修改签名API</h1>
         * <p>
         * 仅“审核中”或者“审核失败”的签名可以进行修改，修改后会重新提交给客服审核。
         * </p>
         * <p>
         * 参数notify，apply_vip，is_only_global如果没有将会修改为默认值
         * </p>
         *
         * <p>
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * old_sign String 是 完整签名内容，用于指定修改哪个签名，可以加【】也可不加 云片网
         * </p>
         * <p>
         * sign String 否 修改后的签名内容（如果要改签名内容） 云片网
         * </p>
         * <p>
         * notify Boolean 否 是否短信通知结果，无此参数默认true true
         * </p>
         * <p>
         * apply_vip Boolean 否 是否申请专用通道，无此参数默认false false
         * </p>
         * <p>
         * is_only_global Boolean 否 是否仅发国际短信，无此参数默认false false
         * </p>
         * <p>
         * industry_type String 否 所属行业，默认“其它” 物联网 其他值例如:1. 游戏 2. 移动应用 3. 视频 4. 教育 5.
         * IT/通信/电子服务 6. 电子商务 7. 金融 8. 网站 9. 商业服务 10. 房地产/建筑 11. 零售/租赁/贸易 12.
         * 生产/加工/制造 13. 交通/物流 14. 文化传媒 15. 能源/电气 16. 政府企业 17. 农业 18. 物联网 19. 其它
         * </p>
         *
         * @param param
         *            old_sign sign notify apply_vip is_only_global industry_type
         * @return
         */
        public Result<Sign> Update(Dictionary<string, string> param)
        {
            var r = new Result<Sign>();
            r = CheckParam(ref param, r, Const.Apikey, Const.OldSign);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Sign>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                        return rsp[Const.Sign].ToObject<Sign>();
                    default: return null;
                }
            });

            try
            {
                Path = "update.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>获取签名API</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * id Long 否 签名id，暂未开放，如果传入此参数将会指定获取某个签名 9527
         * </p>
         * <p>
         * sign String 否 签名内容 云片网
         * </p>
         * <p>
         * page_num Integer 否 页码，1开始，不带或者格式错误返回全部 1
         * </p>
         * <p>
         * page_size Integer 否 返回条数，必须大于0，不带或者格式错误返回全部 20
         * </p>
         *
         * @param param
         *            sign notify page_num page_size
         * @return
         */
        public Result<SignList> Get(Dictionary<string, string> param)
        {
            var r = new Result<SignList>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SignList>(Version, rsp =>
            {
                var list = new SignList();
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        list.Total = rsp[Const.Total].ToObject<int>();
                        list.Sign = rsp[Const.Sign].ToObject<List<Sign>>();
                        return list;
                    }
                    default: return null;
                }
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
    }
}