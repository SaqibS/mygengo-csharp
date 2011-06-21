using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
namespace myGengo.Http
{
    class Utils
    {
        protected static string sendRequest(string method, string url, string data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;
            switch (method)
            {
                case "PUT":
                    req.ContentType = "text/plain";
                    req.ContentLength = data.Length;
                    using (StreamWriter writer = new StreamWriter(req.GetRequestStream())) writer.Write(data);
                    break;
                case "POST":
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = data.Length;
                    using (StreamWriter writer = new StreamWriter(req.GetRequestStream())) writer.Write(data);
                    break;
                case "GET":
                case "DELETE":
                    break;
            }
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            return sr.ReadToEnd();
        }

        public static string urlEncode(string s,bool encode)
        {
            if (!encode)
            {
                return s;
            }
            string ret = "";
            foreach (byte b in Encoding.UTF8.GetBytes(s))
            {
                if (b == 32) ret += "+";
                else if ((b > 47) && (b < 58)) ret += (char)b;
                else if ((b > 64) && (b < 91)) ret += (char)b;
                else if ((b > 96) && (b < 123)) ret += (char)b;
                else if (b == 95 || b == 45 || b == 46) ret += (char)b;
                else ret += "%" + b.ToString("X2");
            }
            return ret;
        }

        public static string buildQuery(IDictionary t)
        {
            return buildQuery(t, true);
        }

        public static string buildQuery(IDictionary query_params,bool encode)
        {
            if (query_params == null || query_params.Count == 0)
            {
                return "";
            }
            string query = "";
            bool first = true;
            foreach (object key in query_params.Keys)
            {
                string skey = (string)key;
                if (!first)
                {
                    query += "&";
                }
                else
                {
                    first = false;
                }
                query += urlEncode(skey, encode) + "=" + urlEncode((string)query_params[skey], encode);
            }
            return query;
        }
    }
}
