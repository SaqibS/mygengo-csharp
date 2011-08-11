namespace MyGengo
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;

    internal class ApiHelper
    {
        private string publicKey;
        private string privateKey;

        public ApiHelper(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
        }

        public IDictionary<string, object> Call(string url, HttpMethod method)
        {
            return Call(url, method, new SortedDictionary<string, object>());
        }

        public IDictionary<string, object> Call(string url, HttpMethod method, SortedDictionary<string, object> parameters)
        {
            parameters.Add("api_key", this.publicKey);
            parameters.Add("ts", DateTime.UtcNow.SecondsSinceEpoch());
                        string queryString = MakeQueryString(parameters);
                        queryString+="&api_sig=" + Sign(queryString);

            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "mygengo-csharp");
            webClient.Headers.Add("accept", "application/json");

            string json = "";
            switch (method)
            {
                case HttpMethod.Get: json = webClient.DownloadString(url + "?" + queryString); break;
                case HttpMethod.Post: break;
                case HttpMethod.Put: break;
                case HttpMethod.Delete: break;
            }

            return new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(json);
        }

        private string MakeQueryString(SortedDictionary<string, object> data)
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, object> kvp in data)
            {
                sb.AppendFormat("&{0}={1}", kvp.Key, HttpUtility.HtmlEncode(kvp.Value));
            }

            sb.Remove(0, 1); // Remove the initial ampersand
            return sb.ToString();
        }

        private string Sign(string s)
        {
            var hash = new HMACSHA1(Encoding.UTF8.GetBytes(this.privateKey));
            byte[] encrypted = hash.ComputeHash(Encoding.UTF8.GetBytes(s));

            var sb = new StringBuilder();
            foreach (byte b in encrypted)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
