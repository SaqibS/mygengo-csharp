/**
 *	Sends a new translation job to myGengo.
 *	Assumes you know/have the Job ID in question.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void CreateJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		var job = new TranslationJob("My slug", "trololololol", "en", "ja", Tier.Standard);
		XDocument response = mygengo.PostTranslationJob(job);
		// response.Root.Element("response") is your ideal response!
	}
}

