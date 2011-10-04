namespace MyGengo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class MyGengoClient
    {
        private const string StandardBaseUrl = "http://api.mygengo.com/v1.1/";
        private const string SandboxBaseUrl = "http://api.sandbox.mygengo.com/v1.1/";

        private string baseUrl = StandardBaseUrl;
        private ApiHelper api;

        public MyGengoClient()
            : this(null, null, false)
        {
        }

        public MyGengoClient(string publicKey, string privateKey)
            : this(publicKey, privateKey, false)
        {
        }

        public MyGengoClient(string publicKey, string privateKey, bool useSandbox)
        {
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;
            this.UseSandbox=useSandbox;
            api = new ApiHelper(this.PublicKey, this.PrivateKey);
        }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public bool UseSandbox
        {
            get { return baseUrl==StandardBaseUrl; }
                        set { baseUrl= value? SandboxBaseUrl: StandardBaseUrl; }
        }

        public XDocument GetAccountStats()
        {
            try
            {
                string url = baseUrl + "account/stats/";
                                                                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
                                        }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetAccountBalance()
        {
                        try
            {
                string url = baseUrl + "account/balance/";
                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
                        catch (MyGengoException x) { throw x; }
                        catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument PostTranslationJob(TranslationJob job)
        {
                        try
            {
                            string url = baseUrl + "translate/job/";
                            var data = new Dictionary<string, object>();
                            data.Add("job", job.ToDictionary());
                            return api.Call(url, HttpMethod.Post, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument PostTranslationJobs(TranslationJob[] jobs, bool processAsGroup=false, bool shouldProcess=true)
        {
                        try
            {
                string url = baseUrl + "translate/jobs/";
                var data = new Dictionary<string, object>();
                data.Add("jobs", jobs.Select(x => x.ToDictionary()).ToArray());
                data.Add("as_group", processAsGroup ? 1 : 0);
                data.Add("process", shouldProcess ? 1 : 0);
return api.Call(url, HttpMethod.Post, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }
                
        public XDocument PurchaseTranslationJob(string id)
        {
            try
            {
                string url = baseUrl + "translate/job/" + id + "/";
                var data = new Dictionary<string, object>();
                data.Add("action", "purchase");
                return api.Call(url, HttpMethod.Put, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument ReviseTranslationJob(string id, string comments)
        {
            try
            {
                string url = baseUrl + "translate/job/" + id + "/";
                var data = new Dictionary<string, object>();
                data.Add("action", "revise");
                data.Add("comment", comments);
                return api.Call(url, HttpMethod.Put, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument ApproveTranslationJob(string id, Rating rating, string commentsForTranslator = "", string commentsForMyGengo = "", bool feedbackIsPublic = false)
        {
            try
            {
                string url = baseUrl + "translate/job/" + id + "/";
                var data = new Dictionary<string, object>();
                data.Add("action", "approve");
                data.Add("for_translator", commentsForTranslator);
                data.Add("for_mygengo", commentsForMyGengo);
                data.Add("public", feedbackIsPublic ? "1" : "0");
                switch (rating)
                {
                    case Rating.OneStar: data.Add("rating", "1"); break;
                    case Rating.TwoStars: data.Add("rating", "2"); break;
                    case Rating.ThreeStars: data.Add("rating", "3"); break;
                    case Rating.FourStars: data.Add("rating", "4"); break;
                    case Rating.FiveStars: data.Add("rating", "5"); break;
                    default: throw new ArgumentException("rating");
                }
                return api.Call(url, HttpMethod.Put, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument RejectTranslationJob(string id, RejectReason reason, string comments, string captcha, bool requeue)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id + "/";
                var data = new Dictionary<string, object>();
                data.Add("reason", reason.ToString().ToLower());
                data.Add("comment", comments);
                data.Add("captcha", captcha);
                data.Add("follow_up", requeue ? "requeue" : "cancel");
                return api.Call(url, HttpMethod.Put, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJob(string id)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id + "/";
				return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobs()
        {
                        try
            {
                string url = baseUrl + "translate/jobs/";
				return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobBatch(string group_id)
        {
                        try
            {
                            string url = baseUrl + "translate/jobs/group/" + group_id + "/";
							return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

                public XDocument PostTranslationJobComment(string id, string comment)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id + "/comment";
                var data = new Dictionary<string, object>();
                data.Add("body", comment);
                return api.Call(url, HttpMethod.Post, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobComments(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/comments/";
							return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobFeedback(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/feedback/";
							return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobRevisions(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/revisions/";
							return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobRevision(string id, string revisionId)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/revision/" + revisionId + "/";
							return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobPreviewImage(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/preview/";
							return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument DeleteTranslationJob(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/";
							return api.Call(url, HttpMethod.Delete, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument DeleteTranslationJobs(int[] ids)
        {
                        try
            {
                            string url = baseUrl + "translate/jobs";
							var data = new Dictionary<string, object>();
							data.Add("job_ids", ids);
							return api.Call(url, HttpMethod.Delete, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetServiceLanguages()
        {
            try
            {
                string url = baseUrl + "translate/service/languages/";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetServiceLanguagePairs()
        {
                        try
            {
                string url = baseUrl + "translate/service/language_pairs/";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetServiceLanguagePairs(string sourceLanguageCode)
        {
            try
            {
                string url = baseUrl + "translate/service/language_pairs/";

                var data = new Dictionary<string, object>();
                data["lc_src"] = sourceLanguageCode;
                return api.Call(url, HttpMethod.Get, data);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument DetermineTranslationCost(TranslationJob[] jobs, bool processAsGroup=false, bool shouldProcess=true)
        {
                        try
            {
                string url = baseUrl + "translate/service/quote/";
				var data = new Dictionary<string, object>();
                data.Add("jobs", jobs.Select(x => x.ToDictionary()).ToArray());
                data.Add("as_group", processAsGroup ? 1 : 0);
                data.Add("process", shouldProcess ? 1 : 0);
				return api.Call(url, HttpMethod.Post, data, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }
    }
}
