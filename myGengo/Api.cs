using System;
using System.Collections;
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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using myGengo.Http;
using myGengo.Apis;
using System.Net;
using System.IO;
namespace myGengo
{
    abstract class Api
    {
        protected Config config = null;
        protected HttpWebResponse response = null;
        protected Client client = null;
        protected string DEFAULT_ID = "0";
        /**
         * we will have 2 constructors
         */
        public Api(string api_key, string private_key)
        {
            config = Config.getInstance();
            client = Client.getInstance();
            if (api_key != null)
            {
                setApiKey(api_key);
            }
            if (private_key != null)
            {
                setPrivateKey(private_key);
            }
        }

        public Api()
        {
            config = Config.getInstance();
            client = Client.getInstance();
        }

        public void setApiKey(string api_key)
        {
            config["api_key"] = api_key;
        }

        public void setPrivateKey(string private_key)
        {
            config["private_key"] = private_key;
        }

        public void setResponseFormat(string format)
        {
            format = format.ToLower();
            string[] valid = { "xml", "json" };
            if (!valid.Contains(format))
            {
                throw new GengoException("Invalid response format: "+ format +", accepted formats are: xml or json.");
            }
            config["format"] = format;
        }

        public void setBaseUrl(string url)
        {
            if (!url.EndsWith("/"))
            {
                url = url + "/";
            }
            config["baseurl"] = url;
        }

        protected void checkResponse()
        {
            if (response == null)
            {
                throw new GengoException("A valid response is not yet available, please make a request first.");
            }
        }

        public override string ToString()
        {
            return response.ToString();
        }

         /**
         * @param string client The name of the clinet to instantiate (job, jobs, account or service)
         * @param string api_key user api key
         * @param string private_key user secret key
         * @return A myGengo Api client
         */
        public static Api factory(string client)
        {
            return factory(client, null, null);
        }
        public static Api factory(string client, string api_key, string private_key)
        {
            switch (client)
            {
            case "job":
                return new Job(api_key, private_key);
            case "jobs":
                return new Jobs(api_key, private_key);
            case "account":
                return new Account(api_key, private_key);
            case "service":
                return new Service(api_key, private_key);
            }
            throw new GengoException("Invalid client: " + client + ", accepted clients are: job,jobs,account and service.");
        }

        /**
        * Set the passed parameters that are null with default
        * configuration values
        */
        protected void setParams(ref object id,ref string format,ref IDictionary param)
        {
            if (id == null)
            {
                id = config["job_id"];
            }
            if (format == null)
            {
                format = this.config["format"];
            }
            if (param == null)
            {
                param = new SortedDictionary<string,object>();
                string private_key = this.config["private_key"];
                param["ts"] = Config.timestamp();
                param["api_key"] = this.config["api_key"];
                string query = Http.Utils.buildQuery(param);
                param["api_sig"] = Crypto.sign(query, private_key);
            }
        }
        protected void setParamsNotId(ref string format,ref IDictionary param)
        {
            object foo_id = new object();
            setParams(ref foo_id, ref format, ref param);
        }

        public string getResponseBody()
        {
            checkResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

    }
}
