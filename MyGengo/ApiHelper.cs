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
        private JavaScriptSerializer jsSerializer;

        public ApiHelper(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
            jsSerializer = new JavaScriptSerializer();
        }

        public IDictionary<string, object> Call(string url, HttpMethod method)
        {
            return Call(url, method, new SortedDictionary<string, string>());
        }

        public IDictionary<string, object> Call(string url, HttpMethod method, SortedDictionary<string, string> parameters)
        {
            parameters.Add("api_key", this.publicKey);
            parameters.Add("ts", DateTime.UtcNow.SecondsSinceEpoch().ToString());
            parameters.Add("api_sig", Sign(MakeQueryString(parameters)));
            string queryString = MakeQueryString(parameters);

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

            Dictionary<string, object> response = jsSerializer.Deserialize<Dictionary<string, object>>(json);
            if ((string)response["opstat"] == "error")
            {
                Dictionary<string, object> error = (Dictionary<string, object>)response["err"];
                throw new MyGengoException(string.Format("{0} (error code {1})", error["msg"], error["code"]));
            }

            return response;
        }

        private string MakeQueryString(SortedDictionary<string, string> data)
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in data)
            {
                sb.AppendFormat("&{0}={1}", UrlEncode(kvp.Key), UrlEncode(kvp.Value));
            }

            sb.Remove(0, 1); // Remove the initial ampersand
            return sb.ToString();
        }

        private string UrlEncode(string s)
        {
            string encoded = "";
            foreach (byte b in Encoding.UTF8.GetBytes(s))
            {
                if (b == 32) encoded += "+";
                else if ((b > 47) && (b < 58)) encoded += (char)b;
                else if ((b > 64) && (b < 91)) encoded += (char)b;
                else if ((b > 96) && (b < 123)) encoded += (char)b;
                else if (b == 95 || b == 45 || b == 46) encoded += (char)b;
                else encoded += "%" + b.ToString("X2");
            }

            return encoded;
        }

        private string Sign(string s)
        {
            var hash = new HMACSHA1(Encoding.UTF8.GetBytes(this.privateKey));
            byte[] encrypted = hash.ComputeHash(Encoding.UTF8.GetBytes(s));

            // Convert to hex
            var sb = new StringBuilder(capacity: encrypted.Length * 2);
            foreach (byte b in encrypted)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
