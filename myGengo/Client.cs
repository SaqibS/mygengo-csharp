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
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Net;
namespace myGengo
{
    class Client
    {
        protected static Client instance = null;
        protected HttpWebRequest client = null;//a web client
        protected Config config = null;
        /**
         * singleton class
         */
        protected Client()
        {
            config = Config.getInstance();
        }

        public static Client getInstance()
        {
            if(null == instance)
            {
                instance = new Client();
            }
            return instance;
        }

        public HttpWebResponse get(string url, string format, IDictionary param)
        {
            return (HttpWebResponse)this.request(url, Client.GET, format, param);
        }

        public HttpWebResponse post(string url, string format, IDictionary param)
        {
            return (HttpWebResponse)this.request(url, Client.POST, format, param);
        }

        public HttpWebResponse put(string url, string format, IDictionary param)
        {
            return (HttpWebResponse)this.request(url, Client.PUT, format, param);
        }

        public HttpWebResponse delete(string url, string format, IDictionary param)
        {
            return (HttpWebResponse)this.request(url, Client.DELETE, format, param);
        }

        public static string GET = "get";
        public static string POST = "post";
        public static string PUT = "put";
        public static string DELETE = "delete";

        public WebResponse request(string url, string method, string format, IDictionary param)
        {
            format = format.ToLower();
            string[] formats = { "xml", "json" };
            if (!formats.Contains(format))
            {
                throw new GengoException("Invalid response format: " + format + ", accepted formats are: json or xml.");
            }
            method = method.ToUpper();
            string[] methods = { "GET", "POST", "PUT", "DELETE" };
            if (!methods.Contains(method))
            {
                throw new GengoException("HTTP method: " + method + " not supported");
            }
            string data = Http.Utils.buildQuery(param);
            switch (method)
            {
                case "GET":
                    url = url + "?" + data;
                    client = (HttpWebRequest)WebRequest.Create(url);
                    client.Method = method;
                    switch (format)
                    {
                        case "xml":
                            client.Accept = "application/xml";
                            break;
                        case "json":
                            client.Accept = "application/json";
                            break;
                    }
                    break;
                case "PUT":
                    client = (HttpWebRequest)WebRequest.Create(url);
                    client.Method = method;
                    switch (format)
                    {
                        case "xml":
                            client.Accept = "application/xml";
                            break;
                        case "json":
                            client.Accept = "application/json";
                            break;
                    }
                    client.ContentType = "text/plain";
                    using (StreamWriter writer = new StreamWriter(client.GetRequestStream())) writer.Write(data);
                    break;
                case "POST":
                    client = (HttpWebRequest)WebRequest.Create(url);
                    client.Method = method;
                    switch (format)
                    {
                        case "xml":
                            client.Accept = "application/xml";
                            break;
                        case "json":
                            client.Accept = "application/json";
                            break;
                    }
                    client.Accept = "application/json";
                    client.ContentType = "application/x-www-form-urlencoded";
                    client.ContentLength = data.Length;
                    using (StreamWriter writer = new StreamWriter(client.GetRequestStream())) writer.Write(data);
                    break;
            }
            try
            {
                client.UserAgent = "csharpMyGengo 1.0";
                return client.GetResponse();
            }
            catch (Exception e)
            {
                throw new GengoException(e.Message);
            }
        }
    }
}
