using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yunpian.Sdk.Model;

//using System.Web;


namespace Yunpian.Sdk.Api
{
    public class YunpianApi : IApiResult
    {
        private YunpianClient _clnt;

        public string Host { get; set; }

        public string Version { get; set; }

        public string Path { get; set; }
        public string Apikey { get; set; }
        public string Charset { get; set; }
        public string Name { get; set; }

        public Result<T> ApiResult<TR, T>(string rspStr, IResultHandler<TR, T> h, Result<T> r)
        {
            //Console.WriteLine(rspStr);
            var rsp = h.Response(rspStr);
            var code = h.Code(rsp);
            return code == Const.Ok ? h.Succ(code, rsp, r) : h.Fail(code, rsp, r);
        }

        public virtual void Init(YunpianClient clnt)
        {
            if (clnt == null) return;
            _clnt = clnt;
            Apikey = clnt.Conf().Apikey();
            Version = clnt.Conf().Get(Const.YpVersion, Const.VersionV2);
            Charset = clnt.Conf().Get(Const.HttpCharset, Const.HttpCharsetDefault);
        }

        private string Uri()
        {
            return string.Format("{0}/{1}/{2}/{3}", Host, Version, Name, Path);
        }

        protected YunpianClient Client()
        {
            return _clnt;
        }

        public static int Code(JObject rsp, string version)
        {
            var code = Const.UnknownException;
            if (rsp == null) return code;

            if (version == null)
                version = Const.VersionV2;

            switch (version)
            {
                case Const.VersionV1:
                    code = rsp[Const.Code]?.ToObject<int>() ?? Const.UnknownException;
                    break;
                case Const.VersionV2:
                    code = rsp[Const.Code]?.ToObject<int>() ?? Const.Ok;
                    break;
            }

            return code;
        }


        protected Result<T> Post<TR, T>(ref string data, ResultHandler<TR, T> h, Result<T> r)
        {
            try
            {
                //Console.WriteLine(data);
                return ApiResult(_clnt.Post(Uri(), data, Charset).Result, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        protected Result<T> Post<TR, T>(HttpContent data, ResultHandler<TR, T> h, Result<T> r)
        {
            try
            {
                //Console.WriteLine(data);
                return ApiResult(_clnt.Post(Uri(), data, Charset).Result, h, r);
            }
            catch (Exception e)
            {
                return h.CatchExceptoin(e, r);
            }
        }

        protected Result<T> CheckParam<T>(ref Dictionary<string, string> param, Result<T> r, params string[] must)
        {
            if (param == null)
                param = new Dictionary<string, string>();
            if (r == null)
                r = new Result<T>();

            if (!param.ContainsKey(Const.Apikey))
                param[Const.Apikey] = Client().Conf().Apikey(); //default apikey

            foreach (var p in must)
            {
                if (param.ContainsKey(p)) continue;

                r.Code = Const.ArgumentMissing;
                r.Msg = $"miss {p}";
                break;
            }

            return r;
        }

        protected string UrlEncode(ref Dictionary<string, string> param)
        {
            var encoding = Encoding.GetEncoding(Charset);
            return string.Join("&",
                param.Select(kv => string.Format("{0}={1}", HttpUtility.UrlEncode(kv.Key, encoding),
                    HttpUtility.UrlEncode(kv.Value, encoding))));
        }
    }


    public interface IApiResult
    {
        Result<T> ApiResult<TR, T>(string rsp, IResultHandler<TR, T> h, Result<T> r);
    }

    public interface IResultHandler<TR, T>
    {
        TR Response(string rsp);

        int Code(TR rsp);

        Result<T> Succ(int code, TR rsp, Result<T> r);

        Result<T> Fail(int code, TR rsp, Result<T> r);

        Result<T> CatchExceptoin(Exception e, Result<T> r);
    }

    public abstract class ResultHandler<TR, T> : IResultHandler<TR, T>
    {
        public abstract TR Response(string rsp);
        public abstract int Code(TR rsp);
        public abstract Result<T> Succ(int code, TR rsp, Result<T> r);
        public abstract Result<T> Fail(int code, TR rsp, Result<T> r);

        public Result<T> CatchExceptoin(Exception e, Result<T> r)
        {
            if (r == null) r = new Result<T>();

            r.Code = Const.UnknownException;
            r.E = e;
            return r;
        }
    }

    public class MapResultHandler<T> : ResultHandler<JObject, T>
    {
        private readonly Func<JObject, T> _data;
        private readonly string _v;

        public MapResultHandler(string version, Func<JObject, T> data)
        {
            _v = version;
            _data = data;
        }

        public override JObject Response(string rsp)
        {
            //Console.WriteLine(rsp);
            return rsp == null
                ? new JObject()
                : JObject.Parse(rsp);
        }

        public override int Code(JObject rsp)
        {
            return YunpianApi.Code(rsp, _v);
        }


        public override Result<T> Succ(int code, JObject rsp, Result<T> r)
        {
            if (r == null)
                r = new Result<T>();

            r.Code = code;
            r.Data = _data(rsp);
            return r;
        }


        /**
         * 错误流程 v1和v2返回格式一致
         */
        public override Result<T> Fail(int code, JObject rsp, Result<T> r)
        {
            if (r == null)
                r = new Result<T>();

            r.Code = code;
            r.Msg = rsp[Const.Msg]?.ToString();
            r.Detail = rsp[Const.Detail]?.ToString();
            return r;
        }
    }

    /**
     * 处理返回json数组的情况,在传回非数组时，用map方式解析到rspMap。设计不好，最好统一用map格式
     * 
     */
    public class ListMapResultHandler<T> : ResultHandler<JContainer, List<T>>
    {
        private readonly Func<JContainer, List<T>> _data;
        private readonly string _v;


        public ListMapResultHandler(string version, Func<JContainer, List<T>> data)
        {
            _v = version;
            _data = data;
        }

        public override JContainer Response(string rsp)
        {
            if (rsp != null && rsp[0] == '[') return JArray.Parse(rsp);

            return JObject.Parse(rsp);
        }

        public override int Code(JContainer rsp)
        {
            return rsp is JObject o ? YunpianApi.Code(o, _v) : Const.Ok;
        }

        public override Result<List<T>> Succ(int code, JContainer rsp, Result<List<T>> r)
        {
            if (r == null) r = new Result<List<T>>();

            r.Code = code;
            r.Data = _data(rsp);
            return r;
        }


        /**
         * 错误流程 v1和v2返回格式一致
         */
        public override Result<List<T>> Fail(int code, JContainer rsp, Result<List<T>> r)
        {
            if (r == null) r = new Result<List<T>>();

            r.Code = code;

            if (rsp is JObject o)
            {
                r.Msg = o[Const.Msg]?.ToString();
                r.Detail = o[Const.Detail]?.ToString();
            }

            return r;
        }
    }

    public class SimpleListResultHandler<T> : ListMapResultHandler<T>
    {
        public SimpleListResultHandler(string version) : base(version, rsp => rsp.ToObject<List<T>>())
        {
        }
    }

    public class StdResultHandler<T> : ResultHandler<Result<T>, T>
    {
        public override Result<T> Response(string rsp)
        {
            return JsonConvert.DeserializeObject<Result<T>>(rsp);
        }

        public override int Code(Result<T> rsp)
        {
            return rsp.Code;
        }

        public override Result<T> Succ(int code, Result<T> rsp, Result<T> r)
        {
            return rsp;
        }

        public override Result<T> Fail(int code, Result<T> rsp, Result<T> r)
        {
            return rsp;
        }
    }

    public class ValueResultHandler<T> : ResultHandler<Result<T>, T>
    {
        private readonly Func<string, T> _data;
        private readonly string _v;


        public ValueResultHandler(string version, Func<string, T> data)
        {
            _v = version;
            _data = data;
        }

        public override Result<T> Response(string rsp)
        {
            if (rsp != null && rsp[0] == '{') return JsonConvert.DeserializeObject<Result<T>>(rsp);

            return new Result<T> {Data = _data(rsp)};
        }

        public override int Code(Result<T> rsp)
        {
            return rsp.Code;
        }

        public override Result<T> Succ(int code, Result<T> rsp, Result<T> r)
        {
            return rsp;
        }

        public override Result<T> Fail(int code, Result<T> rsp, Result<T> r)
        {
            return rsp;
        }
    }
}