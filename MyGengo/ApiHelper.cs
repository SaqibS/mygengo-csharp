namespace MyGengo
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Linq;

    internal class ApiHelper
    {
        private string publicKey;
        private string privateKey;

        public ApiHelper(string publicKey, string privateKey)
        {
            this.publicKey = publicKey;
            this.privateKey = privateKey;
        }

        public XDocument Call(string url, HttpMethod method)
        {
            return Call(url, method, new SortedDictionary<string, string>(), false);
        }

        public XDocument Call(string url, HttpMethod method, bool requiresAuthentication)
        {
            return Call(url, method, new SortedDictionary<string, string>(), requiresAuthentication);
        }

        public XDocument Call(string url, HttpMethod method, SortedDictionary<string, string> parameters)
        {
            return Call(url, method, parameters, false);
        }

        public XDocument Call(string url, HttpMethod method, SortedDictionary<string, string> parameters, bool requiresAuthentication)
        {
            if (requiresAuthentication && (string.IsNullOrEmpty(this.publicKey) || string.IsNullOrEmpty(this.privateKey)))
            {
                throw new MyGengoException("This API requires authentication. Both a public and private key must be specified.");
            }

                        parameters.Add("api_key", this.publicKey);

                        if (requiresAuthentication)
                        {
                            parameters.Add("ts", DateTime.UtcNow.SecondsSinceEpoch().ToString());
                            parameters.Add("api_sig", Sign(MakeQueryString(parameters)));
                        }

            string queryString = MakeQueryString(parameters);
            url += "?" + queryString;

            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "mygengo-csharp");
            webClient.Headers.Add("accept", "application/xml");

            string xml = "";
            switch (method)
            {
                case HttpMethod.Get: xml = webClient.DownloadString(url); break;
                case HttpMethod.Post: break;
                case HttpMethod.Put: break;
                case HttpMethod.Delete: break;
            }

            XDocument doc;
            try
            {
                doc = XDocument.Parse(xml);
            }
            catch (Exception x)
            {
                var mgx = new MyGengoException("The response returned by myGengo is not valid XML", x);
                mgx.Data.Add("url", url);
                mgx.Data.Add("response", xml);
                throw mgx;
            }

            if (doc.Root.Element("opstat").Value == "error")
            {
                XElement error = doc.Root.Element("response").Element("error");
                throw new MyGengoException(string.Format("{0} (error code {1})", error.Element("msg").Value, error.Element("code").Value));
            }

            return doc;
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

        // This method is very similar to HttpUtility.UrlEncode()
        // However, the former does not encode parentheses, which is required by myGengo
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
