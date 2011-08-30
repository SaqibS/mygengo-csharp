/**
 *	Returns your myGengo account balance.
 */

using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void ReturnAccountBalance()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		XDocument response = mygengo.GetAccountBalance();
		// response.Root.Element("response") is your ideal response!
	}
}

