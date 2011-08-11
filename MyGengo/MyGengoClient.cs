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

        public string GetAccountBalance()
        {
            //		'url': '/account/balance',
            try
            {
return "";
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

        public string PostTranslationJob()
        {
            //		'url': '/translate/job',
            try
            {
return "";
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

        public string PostTranslationJobs()
        {
            //		'url': '/translate/jobs',
            try
            {
return "";
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

        public string UpdateTranslationJob(string id)
        {
            //		'url': '/translate/job/{{id}}',
            try
            {
return "";
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

        public string GetTranslationJob(string id)
        {
            //		'url': '/translate/job/{{id}}',
            try
            {
return "";
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

        public string GetTranslationJobs()
        {
            //		'url': '/translate/jobs',
            try
            {
return "";
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

        public string GetTranslationJobBatch(string id)
        {
            //		'url': '/translate/jobs/{{id}}',
            try
            {
return "";
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

        public string DetermineTranslationCost()
        {
            //		'url': '/translate/service/quote',
            try
            {
return "";
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

        public string PostTranslationJobComment(string id)
        {
            //		'url': '/translate/job/{{id}}/comment',
            try
            {
return "";
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

        public string GetTranslationJobComments(string id)
        {
            //		'url': '/translate/job/{{id}}/comments',
            try
            {
return "";
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

        public string GetTranslationJobFeedback(string id)
        {
            //		'url': '/translate/job/{{id}}/feedback',
            try
            {
return "";
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

        public string GetTranslationJobRevisions(string id)
        {
            //		'url': '/translate/job/{{id}}/revisions',
            try
            {
return "";
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

        public string GetTranslationJobRevision(string id, string revisionId)
        {
            //		'url': '/translate/job/{{id}}/revisions/{{revision_id}}',
            try
            {
return "";
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

        public string GetTranslationJobPreviewImage(string id)
        {
            //		'url': '/translate/job/{{id}}/preview',
            try
            {
return "";
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

        public string DeleteTranslationJob(string id)
        {
            //		'url': '/translate/job/{{id}}',
            try
            {
return "";
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

        public string GetServiceLanguagePairs()
        {
            //		'url': '/translate/service/language_pairs',
            try
            {
return "";
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

        public string GetServiceLanguages()
        {
            //		'url': '/translate/service/languages',
            try
            {
return "";
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
