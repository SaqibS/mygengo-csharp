/**
 *	Returns an estimate of the cost of the job in question.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void DetermineTranslationCost()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		var job = new TranslationJob("Slug", "Mmmhmm, yes, yes, quite right", "en", "ja", Tier.Standard);
		XDocument response = mygengo.DetermineTranslationCost(job);
		// response.Root.Element("response") is your ideal response!
	}
}

