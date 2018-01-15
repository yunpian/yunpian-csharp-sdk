using System.Linq;
using System.Text;
using System.Web;
using Yunpian.Sdk.Model;

namespace Yunpian.Sdk.Util
{
    public static class ApiUtil
    {
        public static string UrlEncodeAndLink(string charset, string seperator, params string[] text)
        {
            if (charset == null)
                charset = Const.HttpCharsetDefault;

            if (seperator == null)
                seperator = Const.SeperatorComma;

            var encoding = Encoding.GetEncoding(charset);
            return string.Join(seperator, text.Select(t => HttpUtility.UrlEncode(t, encoding)));
            // return string.Join(seperator, text);
        }
    }
}