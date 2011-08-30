/**
 *	GETS a specific revision on a job previously posted to myGengo.
 *	Assumes you know/have the Job ID in question.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void JobRevision()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.GetTranslationJobRevision('42', '1'); // job_id, revision_id
		// response.Root.Element("opstat") is your ideal response!
	}
}

