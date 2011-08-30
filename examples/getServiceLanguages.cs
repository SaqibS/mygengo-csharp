/**
 *	Returns supported myGengo languages.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void ReturnLanguages()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.GetServiceLanguages();
		// response.Root.Element("response") is your ideal response!
	}
}

