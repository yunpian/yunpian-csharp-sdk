using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Api
{
    public class TplApi : YunpianApi
    {
        public const string ApiName = "tpl";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpTplHost, "https://sms.yunpian.com");
        }

        /**
         * <h1>取默认模板</h1>
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_id Long 否 模板id，64位长整形。指定id时返回id对应的默认 模板。未指定时返回所有默认模板 1
         * </p>
         * 
         * @param param
         *            tpl_id
         * @return
         */
        public Result<List<Template>> GetDefault(Dictionary<string, string> param)
        {
            var r = new Result<List<Template>>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new SimpleListResultHandler<Template>(Version);

            try
            {
                Path = "get_default.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>取模板</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_id Long 否 模板id，64位长整形。指定id时返回id对应的 模板。未指定时返回所有模板 1
         * </p>
         * 
         * @param param
         *            tpl_id
         * @return
         */
        public Result<List<Template>> Get(Dictionary<string, string> param)
        {
            var r = new Result<List<Template>>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new ListMapResultHandler<Template>(Version, rsp =>
            {
                if (rsp != null)
                    switch (Version)
                    {
                        case Const.VersionV1:
                        {
                            if (rsp is JObject o)
                            {
                                var tpl = o[Const.Template];
                                return tpl.GetType().IsArray
                                    ? tpl.ToObject<List<Template>>()
                                    : new List<Template> {tpl.ToObject<Template>()};
                            }

                            break;
                        }
                        case Const.VersionV2:
                        {
                            var list = new List<Template> {rsp.ToObject<Template>()};
                            return list;
                        }
                    }

                return new List<Template>();
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
         * <h1>添加模板</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_content String 是 模板内容，必须以带符号【】的签名开头 【云片网】您的验证码是#code#
         * </p>
         * <p>
         * notify_type Integer 否 审核结果短信通知的方式: 0表示需要通知,默认; 1表示仅审核不通过时通知; 2表示仅审核通过时通知;
         * 3表示不需要通知 1
         * </p>
         * <p>
         * lang String 否 国际短信模板所需参数，模板语言:简体中文zh_cn; 英文en; 繁体中文 zh_tw; 韩文ko,日文 ja
         * zh_cn
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<Template> Add(Dictionary<string, string> param)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.TplContent);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Template>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                        return rsp[Const.Template].ToObject<Template>();
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<Template>();
                    }
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
         * <h1>删除模板</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_id Long 是 模板id，64位长整形 9527
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<Template> Del(Dictionary<string, string> param)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.TplId);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Template>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<Template>();
                    }
                    default: return null;
                }
            });

            try
            {
                Path = "del.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>修改模板</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_id Long 是 模板id，64位长整形，指定id时返回id对应的模板。未指定时返回所有模板 9527
         * </p>
         * <p>
         * tpl_content String 是
         * 模板id，64位长整形。指定id时返回id对应的模板。未指定时返回所有模板模板内容，必须以带符号【】的签名开头 【云片网】您的验证码是#code#
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<Template> Update(Dictionary<string, string> param)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.TplId, Const.TplContent);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Template>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV1:
                    {
                        return rsp[Const.Template]?.ToObject<Template>();
                    }
                    case Const.VersionV2:
                    {
                        return rsp[Const.Template] != null
                            ? rsp[Const.Template].ToObject<Template>()
                            : rsp.ToObject<Template>();
                    }
                }

                return null;
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
         * <h1>添加语音通知模版</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_content String 是 模板内容，必须以带符号【】的签名开头 【云片网】您的验证码是#code#
         * </p>
         * <p>
         * notify_type Integer 否 审核结果短信通知的方式: 0表示需要通知,默认; 1表示仅审核不通过时通知; 2表示仅审核通过时通知;
         * 3表示不需要通知 1
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<Template> AddVoiceNotify(Dictionary<string, string> param)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.TplContent);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Template>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<Template>();
                    }
                }

                return null;
            });

            try
            {
                Path = "add_voice_notify.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * <h1>修改语音通知模版</h1>
         * 
         * <p>
         * 参数名 类型 是否必须 描述 示例
         * </p>
         * <p>
         * apikey String 是 用户唯一标识 9b11127a9701975c734b8aee81ee3526
         * </p>
         * <p>
         * tpl_id Long 是 模板id，64位长整形，指定id时返回id对应的模板。未指定时返回所有模板 9527
         * </p>
         * <p>
         * tpl_content String 是
         * 模板id，64位长整形。指定id时返回id对应的模板。未指定时返回所有模板模板内容，必须以带符号【】的签名开头 【云片网】您的验证码是#code#
         * </p>
         * 
         * @param param
         * @return
         */
        public Result<Template> UpdateVoiceNotify(Dictionary<string, string> param)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.TplId, Const.TplContent);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<Template>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp[Const.Template] != null
                            ? rsp[Const.Template].ToObject<Template>()
                            : rsp.ToObject<Template>();
                    }
                }

                return null;
            });

            try
            {
                Path = "update_voice_notify.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }
    }
}