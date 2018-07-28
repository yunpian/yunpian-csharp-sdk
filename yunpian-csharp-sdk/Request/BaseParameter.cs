using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.WebUtility;

namespace Yunpian.Sdk.Request
{
    public abstract class BaseParameter : IParameter
    {
        protected readonly Dictionary<string, string> _dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public void Add(string key,string value)
        {
            _dic.Add(key, value);
        }

        public virtual IReadOnlyDictionary<string, string> ToDictionary()
        {
            FlushToDic();
            return _dic;
        }

        public virtual string ToPostString()
        {
            IReadOnlyCollection<KeyValuePair<string,string>> dic = ToDictionary();
            return string.Join("&", dic.OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase).Select(x => $"{UrlEncode(x.Key)}={UrlEncode(x.Value)}");
        }

        protected abstract void FlushToDic();
    }
}
