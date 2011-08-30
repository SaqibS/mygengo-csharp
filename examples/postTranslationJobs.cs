/**
 *	Sends a group translation job to myGengo.
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
		var rnd = new Random();
		var jobs = new TranslationJob[3];

		for (int i = 0; i < 3; i++)
		{
			string text = string.Format("Test{0}ing myGe{1}ngo A{2}PI li{3}brary calls.", rnd.Next(1, 226), rnd.Next(1, 226), rnd.Next(1, 226), rnd.Next(1, 226));
			jobs[i] = new TranslationJob(text, "en", "ja", Tier.Standard);
		}

		/**
		 *	Can pass shouldProcess and/or processAsGroup; former pays immediately, latter
		 *	keeps them all under one translator (advisable for context).
		 */
		XDocument response = myGengo.PostTranslationJobs(jobs, processAsGroup: true, shouldProcess: false);
		// response.Root.Element("response") is your ideal response!
	}
}

