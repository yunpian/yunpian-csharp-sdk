using System;
using System.Collections.Generic;
using System.Text;

namespace Yunpian.Sdk
{
    public class SmsException : Exception
    {
        public string Response { get; }
        public SmsException(string message,string response) : base(message)
        {
            Response = response;
        }
        public SmsException(string message, string response, Exception inner) : base(message, inner)
        {
            Response = response;
        }
    }
}
