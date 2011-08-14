namespace MyGengo
{
    using System;
    using System.Collections.Generic;

    public class MyGengoClient
    {
        private const string StandardBaseUrl = "http://api.mygengo.com/v1/";
        private const string SandboxBaseUrl = "http://api.sandbox.mygengo.com/v1/";

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

        public IDictionary<string, object> GetAccountStats()
        {
            try
            {
                string url = baseUrl + "account/stats";
                                                                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
                                        }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string,object> GetAccountBalance()
        {
                        try
            {
                string url = baseUrl + "account/balance";
                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
                        catch (MyGengoException x) { throw x; }
                        catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> PostTranslationJob()
        {
                        try
            {
                            string url = baseUrl + "translate/job";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> PostTranslationJobs()
        {
                        try
            {
                string url = baseUrl + "translate/jobs";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> UpdateTranslationJob(string id)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJob(string id)
        {
                        try
            {
                string url = baseUrl + "translate/job/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobs()
        {
                        try
            {
                string url = baseUrl + "translate/jobs";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobBatch(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/jobs/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

                public IDictionary<string, object> PostTranslationJobComment(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/comment";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobComments(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/comments";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobFeedback(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/feedback";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobRevisions(string id)
        {
                        try
            {
                            string url = "translate/job/" + id + "/revisions";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobRevision(string id, string revisionId)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/revisions/" + revisionId;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetTranslationJobPreviewImage(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id + "/preview";
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> DeleteTranslationJob(string id)
        {
                        try
            {
                            string url = baseUrl + "translate/job/" + id;
return null;
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetServiceLanguages()
        {
            try
            {
                string url = baseUrl + "translate/service/languages";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> GetServiceLanguagePairs()
        {
                        try
            {
                string url = baseUrl + "translate/service/language_pairs";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x) { throw x; }
            catch (Exception x) { throw new MyGengoException(x.Message, x); }
        }

        public IDictionary<string, object> DetermineTranslationCost()
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
