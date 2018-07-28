using System;
using System.Collections.Generic;
using System.Text;

namespace Yunpian.Sdk
{
    public interface IParameter
    {
        string ToPostString();
        IReadOnlyDictionary<string, string> ToDictionary();

        void Add(string key,string value);
    }
}
