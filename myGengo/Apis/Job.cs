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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
namespace myGengo.Apis
{
    class Job : Api
    {
        public Job(string api_key, string private_key)
            : base(api_key,private_key)
        {
        }
        /**
         * translate/job/{id} (GET)
         *
         * Retrieves a specific job
         *
         * @param int/string id The id of the job to retrieve 
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getJob(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id;
            response = client.get(baseurl, format, param);
        }

        /**
         * translate/job/{id}/comments (GET)
         *
         * Retrieves the comment thread for a job
         *
         * @param string/int id The id of the job to retrieve
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getComments(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id + "/comments";
            response = client.get(baseurl, format, param);
        }

        /**
         * translate/job/{id}/feedback (GET)
         *
         * Retrieves the feedback
         *
         * @param string/int id The id of the job to retrieve
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getFeedback(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id + "/feedback";
            response = client.get(baseurl, format, param);
        }

        /**
         * translate/job/{id}/revisions (GET)
         *
         * Gets list of revision resources for a job.
         *
         * @param string/int id The id of the job to retrieve
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getRevisions(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id + "/revisions";
            response = client.get(baseurl, format, param);
        }

        /**
         * translate/job/{id}/revision/{rev_id}
         *
         * Gets specific revision for a job.
         *
         * @param string/int id The id of the job to retrieve
         * @param int rev_id The id of the revision to retrieve
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void getRevision(object id, object rev_id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            if(rev_id == null || rev_id.ToString() == "")
            {
                rev_id = config["rev_id"];
            }
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id + "/revision/" + rev_id;
            response = client.get(baseurl, format, param);
        }

        /**
         * translate/job/{id} (PUT)
         *
         * Updates a job to translate.
         *
         * ACTION:
         *
         * "purchase" - deducts credits for this job and puts it on the
         * translator queue.  If the job is part of a group, all jobs in
         * the group must be purchased before any of the jobs will be
         * available for translation.
         *
         * @param string/int id The id of the job to purchase
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void putPurchase(object id, string format)
        {
            putPurchase(id, format, null);
        }
        public void putPurchase(object id, string format, IDictionary param)
        {
            if( param == null || param.Count == 0 )
            {
                string private_key = config["private_key"];
                param = new SortedDictionary<string,object>();
                param["ts"] = Config.timestamp();
                param["api_key"] = config["api_key"];

                Hashtable action = new Hashtable();
                action["action"] = "purchase";

                param["data"] = JsonConvert.SerializeObject(action);
                string query = JsonConvert.SerializeObject(param);
                param["api_sig"] = Crypto.sign(query, private_key);
            }
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id;
            response = client.put(baseurl, format, param);
        }

        /**
         * translate/job/{id} (PUT)
         *
         * Updates a job to translate.
         *
         * ACTION:
         * "revise" - returns this job back to the translator for revisions
         * comment (required) the reason to the translator for sending the
         * job back for revisions.
         *
         * @param string/int id The id of the job to revise
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void putRevise(object id, string format, IDictionary param)
        {
            if(param == null || param.Count == 0) {

            }
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id;
            response = client.put(baseurl, format, param);
        }

        /**
         * translate/job/{id} (PUT)
         *
         * Updates a job to translate.
         *
         * ACTION:
         * "approve" - approves job
         * other parameters
         * rating (required) - 1 (poor) to 5 (fantastic)
         * for_translator (optional) - comments for the translator
         * for_mygengo (optional) - comments for myGengo staff (private)
         * public (optional) - 1 (true) / 0 (false, default); whether myGengo can share this feedback publicly
         *
         * @param string/int id The id of the job to approve
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void putApprove(object id, string format, IDictionary param)
        {
            if (param == null || param.Count == 0) {

            }
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id;
            response = client.put(baseurl, format, param);
        }

        /**
         * translate/job/{id} (PUT)
         *
         * Updates a job to translate.
         *
         * ACTION:
         * "reject" - rejects the translation
         * other parameters
         * reason (required) - "quality", "incomplete", "other"
         * comment (required) 
         * captcha (required) - the captcha image text. Each job in a "reviewable" state will
         * have a captcha_url value, which is a URL to an image.  This
         * captcha value is required only if a job is to be rejected.
         * follow_up (optional) - "requeue" (default) or "cancel"
         *
         * @param string/int id The id of the job to reject
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void putReject(object id, string format, IDictionary param)
        {
            if (param == null || param.Count == 0) {

            }
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id;
            response = client.put(baseurl, format, param);
        }

       /**
        * translate/job
        * 
        * Post a new job for translation
        * 
        * @param string format The response format, xml or json
        * @param IDictionary param If passed should contain all the
        * necessary parameters for the request including the api_key and
        * api_sig
        */
        public void postJob(String format, IDictionary param)
        {
            if (param.Count == 0)
            {
                throw new GengoException("in method postJob param is missing required fields");
            }
            if (format.Length == 0)
            {
                format = config["format"];
            }
            string baseurl = config["baseurl"];
            baseurl += "translate/job";
            response = client.post(baseurl, format, param);
        }

        /**
         * translate/job/{id}/comment (POST)
         *
         * Submits a new comment to the job's comment thread.
         *
         * @param string/int id The id of the job to comment on
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void postComment(object id, string format, IDictionary param)
        {
            if (param.Count == 0) {
                throw new GengoException("in method postComment \"param\" must contain a valid \"body\" parameter as the comment");
            }
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id + "/comment";
            response = client.post(baseurl, format, param);
        }

        /**
         * translate/job/{id} (DELETE)
         *
         * Cancels the job. You can only cancel a job if it has not been
         * started already by a translator.
         *
         * @param string/int id The id of the job to cancel
         * @param string format The response string format, xml or json
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void deleteJob(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id;
            response = client.delete(baseurl, format, param);
        }

        /**
         * translate/job/{id}/preview (GET)
         *
         * Renders a JPEG preview of the translated text
         * N.B. - if the request is valid, a raw JPEG stream is returned.
         *
         * @param string/int id The id of the job, if not passed it should be in config
         * @param string format The response string format, xml or json (in case of error)
         * @param IDictionary param If passed should contain all the
         * necessary parameters for the request including the api_key and
         * api_sig
         */
        public void previewJob(object id, string format, IDictionary param)
        {
            setParams(ref id, ref format, ref param);
            string baseurl = config["baseurl"];
            baseurl += "translate/job/" + id + "/preview";
            response = client.get(baseurl, format, param);
        }
    }
}
