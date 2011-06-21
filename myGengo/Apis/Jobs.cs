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

namespace myGengo.Apis
{
    class Jobs : Api
    {
        public Jobs(string api_key, string private_key)
            : base(api_key,private_key)
        {
        }

        /**
         * translate/jobs (POST)
         *
         * Submits a job or group of jobs to translate.
         *
         * @param string format The response format, xml or json
         * @param IDictionary params If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void postJobs(string format, IDictionary param)
        {
            string baseurl = config["baseurl"];
            baseurl += "translate/jobs";
            response = client.post(baseurl, format, param);
        }

        /**
         * translate/jobs (GET)
         *
         * Retrieves a list of resources for the most recent jobs filtered
         * by the given parameters.
         *
         * @param string format The response format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getJobs(string format)
        {
            getJobs(format, null);
        }
        public void getJobs(string format, IDictionary param)
        {
            setParamsNotId(ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/jobs";
            response = client.get(baseurl, format, param);
        }

        /**
         * translate/jobs/{id} (GET)
         *
         * Retrieves the group of jobs that were previously submitted
         * together.
         *
         * @param int id The id of the job group to retrieve
         * @param string format The response format, xml or json
         * @param IDictionary params If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getGroupedJobs(object id, string format)
        {
            getGroupedJobs(id, format, null);
        }
        public void getGroupedJobs(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/jobs/" + id;
            response = client.get(baseurl, format, param);
        }
    }
}
