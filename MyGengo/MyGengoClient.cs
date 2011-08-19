namespace MyGengo
{
    using System;
    using System.Collections.Generic;
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
                string url = baseUrl + "account/stats";
                                                                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
                                        }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetAccountBalance()
        {
                        try
            {
                string url = baseUrl + "account/balance";
                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
                        catch (MyGengoException x) { throw x; }
                        catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument PostTranslationJob(TranslationJob job)
        {
                        try
            {
                            string url = baseUrl + "translate/job";
                            var parameters = new Dictionary<string, string>();
                            var data = new Dictionary<string, object>();
                            data.Add("job", job.ToDictionary());
                            parameters.Add("data", data.ToJson());
                            return api.Call(url, HttpMethod.Post, parameters, requiresAuthentication: true);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument PostTranslationJobs()
        {
                        try
            {
                string url = baseUrl + "translate/jobs";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument UpdateTranslationJob(string id)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJob(string id)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobs()
        {
                        try
            {
                string url = baseUrl + "translate/jobs";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobBatch(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/jobs/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

                public XDocument PostTranslationJobComment(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/comment";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobComments(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/comments";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobFeedback(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/feedback";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobRevisions(string id)
        {
                        try
            {
                            string url = "translate/job/" + id + "/revisions";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobRevision(string id, string revisionId)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/revisions/" + revisionId;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetTranslationJobPreviewImage(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/preview";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument DeleteTranslationJob(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetServiceLanguages()
        {
            try
            {
                string url = baseUrl + "translate/service/languages";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetServiceLanguagePairs()
        {
                        try
            {
                string url = baseUrl + "translate/service/language_pairs";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument GetServiceLanguagePairs(string sourceLanguageCode)
        {
            try
            {
                string url = baseUrl + "translate/service/language_pairs";

                var parameters = new Dictionary<string, string>();
                var data = new Dictionary<string, object>();
                data["lc_src"] = sourceLanguageCode;
                parameters["data"] = data.ToJson();

                return api.Call(url, HttpMethod.Get, parameters);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public XDocument DetermineTranslationCost()
        {
                        try
            {
                            string url = baseUrl + "translate/service/quote";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }
    }
}
