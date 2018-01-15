using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Api
{
    public class VideoSmsApi : YunpianApi
    {
        public const string ApiName = "vsms";

        public override void Init(YunpianClient clnt)
        {
            base.Init(clnt);
            Name = ApiName;
            Host = clnt.Conf().Get(Const.YpVideoSmsHost, "https://vsms.yunpian.com");
        }

        public Result<Template> AddTpl(Dictionary<string, string> param, string layout, byte[] material)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.Sign);
            if (!r.IsSucc())
                return r;


            var data = new MultipartFormDataContent();
            foreach (var kv in param)
                data.Add(new StringContent(kv.Value, Encoding.GetEncoding(Charset),
                    "text/plain"), kv.Key);

            data.Add(new StringContent(layout, Encoding.GetEncoding(Charset),
                "application/x-www-form-urlencoded"), Const.Layout);

            var httpContent = new ByteArrayContent(material);
            httpContent.Headers.Add("Content-Type", $"application/octet-stream;charset={Charset}");
            data.Add(httpContent, Const.Material);


            var h = new StdResultHandler<Template>();
            try
            {
                Path = "add_tpl.json";
                return Post(data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * 获取视频短信模版状态
         * 
         * @param param
         *            apikey tpl_id
         * @return
         */
        public Result<Template> GetTpl(Dictionary<string, string> param)
        {
            var r = new Result<Template>();
            r = CheckParam(ref param, r, Const.Apikey, Const.TplId);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new StdResultHandler<Template>();

            try
            {
                Path = "get_tpl.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        /**
         * 批量发送视频短信
         * 
         * @param param
         *            apikey tpl_id mobile
         * @return
         */
        public Result<SmsBatchSend> TplBatchSend(Dictionary<string, string> param)
        {
            var r = new Result<SmsBatchSend>();
            r = CheckParam(ref param, r, Const.Apikey);

            if (!r.IsSucc())
                return r;
            var data = UrlEncode(ref param);

            var h = new MapResultHandler<SmsBatchSend>(Version, rsp =>
            {
                switch (Version)
                {
                    case Const.VersionV2:
                    {
                        return rsp.ToObject<SmsBatchSend>();
                    }
                }

                return null;
            });

            try
            {
                Path = "tpl_batch_send.json";
                return Post(ref data, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }
    }
}