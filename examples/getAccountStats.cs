/**
 *	Returns your myGengo account stats.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void ReturnAccountStats()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.GetAccountStats();
		// response.Root.Element("response") is your ideal response!
	}
}

