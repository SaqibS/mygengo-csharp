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
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string,object> GetAccountBalance()
        {
                        try
            {
                string url = baseUrl + "account/balance";
                return api.Call(url, HttpMethod.Get, requiresAuthentication: true);
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> PostTranslationJob()
        {
            //		'url': '/translate/job',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> PostTranslationJobs()
        {
            //		'url': '/translate/jobs',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> UpdateTranslationJob(string id)
        {
            //		'url': '/translate/job/{{id}}',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJob(string id)
        {
            //		'url': '/translate/job/{{id}}',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobs()
        {
            //		'url': '/translate/jobs',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobBatch(string id)
        {
            //		'url': '/translate/jobs/{{id}}',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> DetermineTranslationCost()
        {
            //		'url': '/translate/service/quote',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> PostTranslationJobComment(string id)
        {
            //		'url': '/translate/job/{{id}}/comment',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobComments(string id)
        {
            //		'url': '/translate/job/{{id}}/comments',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobFeedback(string id)
        {
            //		'url': '/translate/job/{{id}}/feedback',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobRevisions(string id)
        {
            //		'url': '/translate/job/{{id}}/revisions',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobRevision(string id, string revisionId)
        {
            //		'url': '/translate/job/{{id}}/revisions/{{revision_id}}',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetTranslationJobPreviewImage(string id)
        {
            //		'url': '/translate/job/{{id}}/preview',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> DeleteTranslationJob(string id)
        {
            //		'url': '/translate/job/{{id}}',
            try
            {
return null;
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetServiceLanguages()
        {
                        try
            {
                string url = baseUrl + "translate/service/languages";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }

        public IDictionary<string, object> GetServiceLanguagePairs()
        {
                        try
            {
                string url = baseUrl + "translate/service/language_pairs";
                return api.Call(url, HttpMethod.Get);
            }
            catch (MyGengoException x)
            {
                throw x;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x);
            }
        }
    }
}
