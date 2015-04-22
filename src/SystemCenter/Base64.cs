using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCenter
{
    public class Base64
    {
        public static string DecodeBase64(string result)
        {
            string str = "";
            byte[] numArray = Convert.FromBase64String(result);
            try
            {
                str = Encoding.UTF8.GetString(numArray);
            }
            catch
            {
                str = null;
            }
            return str;
        }

        public static string EncodeBase64(string source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            string base64String = "";
            try
            {
                base64String = Convert.ToBase64String(bytes);
            }
            catch
            {
                base64String = null;
            }
            return base64String;
        }
    }
}
