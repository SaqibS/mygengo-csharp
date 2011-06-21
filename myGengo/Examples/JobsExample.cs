using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myGengo;
using myGengo.Apis;
using System.Collections;
using myGengo.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
namespace myGengo.Examples
{
    class JobsExample : Generic
    {
        public override void test()
        {
            Config config = Config.getInstance();
            SortedDictionary<string, object> param = new SortedDictionary<string, object>();

            string api_key = config["api_key"];
            string private_key = config["private_key"];
            string group_id = config["group_id"];

            printNice("jobs");

            SortedDictionary<string, object> job1 = new SortedDictionary<string, object>();
            job1["type"] = "text";
            job1["slug"] = "API job 1 test";
            job1["body_src"] = "Text to be translated goes here";
            job1["lc_src"] = "en";
            job1["lc_tgt"] = "ja";
            job1["tier"] = "standard";
            job1["auto_approve"] = "true";
            job1["custom_data"] = "1234567日本語";

            SortedDictionary<string, object> job2 = new SortedDictionary<string, object>(job1);

            Hashtable both_jobs = new Hashtable();
            both_jobs["job1"] = job1;
            both_jobs["job2"] = job2;

            Hashtable data = new Hashtable();
            data["jobs"] = both_jobs;
            data["as_group"] = "1";
            data["process"] = "1";

            param["api_key"] = api_key;
            param["ts"] = Config.timestamp();
            param["_method"] = "post";
            param["data"] = JsonConvert.SerializeObject(data);

            Jobs jobs = (Jobs)Account.factory("jobs");
            string enc_params = JsonConvert.SerializeObject(param);
            param["api_sig"] = Crypto.sign(enc_params, private_key);

            printNice("postJobs");
            jobs.postJobs("json", param);
            printNice(jobs.getResponseBody());

            printNice("getJobs");
            jobs.getJobs("json");
            printNice(jobs.getResponseBody());

            printNice("getGroupedJobs");
            jobs.getGroupedJobs(group_id,"json");
            printNice(jobs.getResponseBody());
        }
    }
}
