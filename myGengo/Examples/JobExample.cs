using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myGengo.Apis;
using myGengo;
using myGengo.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace myGengo.Examples
{
    class JobExample : Generic
    {
        public void testLazyLoading()
        {
            Config config = Config.getInstance();
            SortedDictionary<string, object> param = new SortedDictionary<string, object>();

            string api_key = config["api_key"];
            string private_key = config["private_key"];

            SortedDictionary<string, object> job = new SortedDictionary<string, object>();
            job["type"] = "text";
            job["slug"] = "API job 1 test";
            job["body_src"] = "Text to be translated goes here";
            job["lc_src"] = "en";
            job["lc_tgt"] = "ja";
            job["tier"] = "standard";
            job["auto_approve"] = "true";
            job["custom_data"] = "1234567“ú–{Œê";

            Hashtable data = new Hashtable();
            data["job"] = job;

            param["api_key"] = api_key;
            param["ts"] = Config.timestamp();
            param["_method"] = "post";
            param["data"] = JsonConvert.SerializeObject(data);

            Job job_client = (Job)Account.factory("job");
            string enc_params = JsonConvert.SerializeObject(param);
            param["api_sig"] = Crypto.sign(enc_params, private_key);

            printNice("postJob");
            job_client.postJob("json", param);
            printNice(job_client.getResponseBody());
        }

        public override void test()
        {
            Config config = Config.getInstance();
            SortedDictionary<string, object> param = new SortedDictionary<string, object>();
            param["ts"] = Config.timestamp();
            param["api_key"] = config["api_key"];
            param["api_sig"] = Crypto.sign(Utils.buildQuery(param), config["private_key"]);
            printNice("job");
            Job job = (Job)Account.factory("job");

            string job_id = config["job_id"];
            job.getJob(job_id, "json", param);
            printNice("getJob");
            printNice(job.getResponseBody());

            job.getComments(job_id,"json",param);
            printNice("getComments");
            printNice(job.getResponseBody());

            job.getFeedback(job_id, "xml", param);
            printNice("getFeedback");
            printNice(job.getResponseBody());

            job.getRevisions(job_id, "json", param);
            printNice("getRevisions");
            printNice(job.getResponseBody());

            job.getRevision(job_id, null, "json", param);
            printNice("getRevision");
            printNice(job.getResponseBody());

            job.putPurchase(job_id, "json");
            printNice("putPurchase");
            printNice(job.getResponseBody());
        }
    }
}
