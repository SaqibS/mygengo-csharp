/**
 *	Returns supported myGengo language pairs.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void ReturnLanguagePairs()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.GetServiceLanguagePairs();
		// response.Root.Element("response") is your ideal response!
	}
}

