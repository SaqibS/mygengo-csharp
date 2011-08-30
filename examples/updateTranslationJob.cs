/**
 *	Updates a translation job to myGengo.
 *	Assumes you know/have the Job ID in question.
 *
 *	Differs from other libraries in that there are specific
 *	method calls for various actions. Examples below.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void PurchaseJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.PurchaseTranslationJob("42");
		// response.Root.Element("response") is your ideal response!
	}

	public void ReviseJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.ReviseTranslationJob("42", "This job needs more effort");
		// response.Root.Element("response") is your ideal response!
	}

	public void ApproveJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.ApproveTranslationJob("42", Rating.TwoStars, "Thanks!", "All Good", false);
		// response.Root.Element("response") is your ideal response!
	}

	public void RejectJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.RejectTranslationJob("42", RejectReason.Quality, "Thanks!", "Captcha Fill", false);
		// response.Root.Element("response") is your ideal response!
	}
}
