using System;
using System.Collections.Generic;
using System.Text;

namespace Yunpian.Sdk.Util
{
    public static class DictonaryHelper
    {
        public static IDictionary<TKey,TValue> Combin<TKey,TValue>(IEnumerable<KeyValuePair<TKey,TValue>> dic1, IEnumerable<KeyValuePair<TKey,TValue>> dic2,IEqualityComparer<TKey> comparer=null)
        {
            Dictionary<TKey, TValue> newDic = null;
            if(comparer == null)
            {
                newDic = new Dictionary<TKey, TValue>();
            }
            else
            {
                newDic = new Dictionary<TKey, TValue>(comparer);
            }
            void copy(IDictionary<TKey, TValue> receive, IEnumerable<KeyValuePair<TKey, TValue>> target)
            {
                foreach(var item in target)
                {
                    receive[item.Key] = item.Value;
                }
            }
            if(dic1 != null)
            {
                copy(newDic, dic1);
            }

            if(dic2 != null)
            {
                copy(newDic, dic2);
            }

            return newDic;
        }
    }
}
