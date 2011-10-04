/**
 *	Delete a job previously posted to myGengo.
 *	Assumes you know/have the Job ID in question.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void DeleteJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		int[] jobs = [42, 43, 44];
		XDocument response = mygengo.DeleteTranslationJobs(jobs);
		// response.Root.Element("opstat") is your ideal response!
	}
}

