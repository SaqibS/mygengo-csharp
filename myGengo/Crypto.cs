/**
 * myGengo API Client
 *
 * LICENSE
 *
 * This source file is subject to the new BSD license that came
 * with this package in the file LICENSE.txt. It is also available 
 * through the world-wide-web at this URL:
 * http://mygengo.com/services/api/dev-docs/mygengo-code-license
 * If you did not receive a copy of the license and are unable to
 * obtain it through the world-wide-web, please send an email
 * to contact@mygengo.com so we can send you a copy immediately.
 *
 * @category   myGengo
 * @package    API Client Library
 * @copyright  Copyright (c) 2009-2010 myGengo, Inc. (http://mygengo.com)
 * @license    http://mygengo.com/services/api/dev-docs/mygengo-code-license New BSD License
 */

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace myGengo
{
    class Crypto
    {
        public static string Enquote(string s)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }
            char c;
            int i;
            int len = s.Length;
            StringBuilder sb = new StringBuilder(len + 4);
            for (i = 0; i < len; i++)
            {
                c = s[i];
                int tmpc = c;
                if (c < 0 || c > 127)
                {
                    sb.Append("\\u" + String.Format("{0:X}", (uint)System.Convert.ToUInt32(tmpc.ToString())).ToLower());
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private static string hash_hmac(string s,string secret_key)
        {
            s = Enquote(s);
            Encoding encoding = new UTF8Encoding();
            string ret = "";
            HMACSHA1 hash = new HMACSHA1(Encoding.UTF8.GetBytes(secret_key));
            byte[] encoded = hash.ComputeHash(Encoding.UTF8.GetBytes(s));
            foreach (byte b in encoded) ret += b.ToString("x2");
            return ret;
        }
        public static string sign(string data, string secret_key)
        {
            return hash_hmac(data, secret_key);
        }
    }
}
