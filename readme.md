myGengo CSharp Library (for the [myGengo API](http://mygengo.com/))
==========================================================================================================================
Translating your tools and products helps people all over the world access them; this is, of course, a
somewhat tricky problem to solve. **[myGengo](http://mygengo.com/)** is a service that offers human-translation
(which is often a higher quality than machine translation), and an API to manage sending in work and watching
jobs. This is a C-sharp interface to make using the API simpler (some would say incredibly easy). 

Example Code
---------------------------------------------------------------------------------------------------------------------------

``` c#  
using System;
using System.Linq;
using MyGengo;
using System.Xml.Linq;

public class Job
{
	public void CreateJob()
	{
		var mygengo = new MyGengoClient(ApiKeys.PublicKey, ApiKeys.PrivateKey, useSandbox: true);
		var job = new TranslationJob("This is all kinds of awesome", "en", "ja", Tier.Standard);
		XDocument response = mygengo.PostTranslationJob(job);
		// response.Root.Element("response").Element("job") is your ideal response!
	}
}
```

Question, Comments, Complaints, Praise?
---------------------------------------------------------------------------------------------------------------------------
If you have questions or comments and would like to reach us directly, please feel free to do
so at the following outlets. We love hearing from developers!

Email: ryan [at] mygengo dot com  
Twitter: **[@mygengo_dev](http://twitter.com/mygengo_dev)**  

If you come across any issues, please file them on the **[Github project issue tracker](https://github.com/myGengo/mygengo-csharp/issues)**. Thanks!


Credits & License
---------------------------------------------------------------------------------------------------------------------------
This library exists due to the excellent efforts of **[Saqib Shaikh]()**, who graciously donated time and effort to provide
an improved C# interface for interacting with myGengo.

The library itself is licensed under a BSD-style license. See the enclosed LICENSE.txt file for more information.
