using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.DomainLayer
{
    public static class Utils
    {
        public static string ParseRequest(NameValueCollection request)
        {

            string result = string.Empty;
            request.AllKeys.ToList().ForEach(c => result += c + "=" + request[c] + "&");
            return result.Remove(result.Length-1);
        }
    }
}
