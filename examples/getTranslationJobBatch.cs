/**
 *	GETS a job batch previously posted to myGengo, given one ID.
 *	Assumes you know/have the Job ID in question.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void BatchJobs()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.GetTranslationJobBatch('42');
		// response.Root.Element("opstat") is your ideal response!
	}
}

