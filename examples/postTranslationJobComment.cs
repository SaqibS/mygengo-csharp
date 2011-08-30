/**
 *	Adds a new comment to a job on myGengo.
 *	Assumes you know/have the Job ID in question.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void AddJobComment()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.PostTranslationJobComment("42", comment: "Mmmmm better");
		// response.Root.Element("response") is your ideal response!
	}
}

