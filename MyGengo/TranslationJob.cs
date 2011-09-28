namespace MyGengo
{
    using System;
    using System.Collections.Generic;

    public class TranslationJob
    {
        public TranslationJob()
        {
        }

        public TranslationJob(string slug, string textToTranslate, string sourceLanguageCode, string targetLanguageCode, Tier tier)
        {
            this.TextToTranslate = textToTranslate;
            this.SourceLanguageCode = sourceLanguageCode;
            this.TargetLanguageCode = targetLanguageCode;
            this.Tier = tier;
			this.Slug = slug;
        }

        public string TextToTranslate { get; set; }
        public string SourceLanguageCode { get; set; }
        public string TargetLanguageCode { get; set; }
		public string Slug { get; set; }
        public Tier Tier { get; set; }

        // Optional fields
        public bool ForceNewTranslation { get; set; }
        public string Comment { get; set; }
        public bool UsePreferredTranslators { get; set; }
        public string CallbackUrl { get; set; }
        public bool AutoApprove { get; set; }

        private byte[] customData;
        public byte[] CustomData
        {
            get { return this.customData; }
            set
            {
                if (value.Length > 1024) throw new MyGengoException("Maximum comment length is 1K");
                    this.customData = value;
            }
        }

        internal Dictionary<string,object> ToDictionary()
        {
			if (string.IsNullOrEmpty(this.Slug)) throw new MyGengoException("Invalid translation job - Slug is required.");
            if (string.IsNullOrEmpty(this.TextToTranslate)) throw new MyGengoException("Invalid translation job - TextToTranslate is required.");
            if (string.IsNullOrEmpty(this.SourceLanguageCode)) throw new MyGengoException("Invalid translation job - SourceLanguageCode is required.");
            if (string.IsNullOrEmpty(this.TargetLanguageCode)) throw new MyGengoException("Invalid translation job - TargetLanguageCode is required.");

            var dictionary = new Dictionary<string, object>();
			dictionary.Add("slug", this.Slug);
            dictionary.Add("body_src", this.TextToTranslate);
            dictionary.Add("lc_src", this.SourceLanguageCode);
            dictionary.Add("lc_tgt", this.TargetLanguageCode);
			dictionary.Add("tier", this.Tier.ToString().ToLower());

            if (this.ForceNewTranslation) dictionary.Add("force", 1);
            if (!string.IsNullOrEmpty(Comment)) dictionary.Add("comment", this.Comment);
            if (this.UsePreferredTranslators) dictionary.Add("use_preferred", 1);
            if (!string.IsNullOrEmpty(this.CallbackUrl)) dictionary.Add("callback_url", this.CallbackUrl);
            if (this.AutoApprove) dictionary.Add("auto_approve", 1);
            if (this.CustomData!=null && this.CustomData.Length>0) dictionary.Add("custom_data", this.CustomData);

            return dictionary;
        }
    }
}
