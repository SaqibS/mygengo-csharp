myGengo CSharp Library (for the [myGengo API](http://mygengo.com/))
==========================================================================================================================
Translating your tools and products helps people all over the world access them; this is, of course, a
somewhat tricky problem to solve. **[myGengo](http://mygengo.com/)** is a service that offers human-translation
(which is often a higher quality than machine translation), and an API to manage sending in work and watching
jobs. This is a C-sharp interface to make using the API simpler (some would say incredibly easy). 

Example Code
---------------------------------------------------------------------------------------------------------------------------

`` c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myGengo.Apis;
using myGengo.Http;

namespace myGengo.Examples
{
    class AccountExample : Generic
    {
        public override void test()
        {
            printNice("account");
            Config config = Config.getInstance();
            SortedDictionary<string, object> param = new SortedDictionary<string, object>();
            param["ts"] = Config.timestamp();
            param["api_key"] = config["api_key"];
            param["api_sig"] = Crypto.sign(Utils.buildQuery(param), config["private_key"]);
            Account account = (Account)Api.factory("account");

            printNice("getBalance");
            account.getBalance("json", param);
            printNice(account.getResponseBody());
            printNice("getStats");
            account.getStats("xml", param);
            printNice(account.getResponseBody());
        }
    }
}
``

Question, Comments, Complaints, Praise?
---------------------------------------------------------------------------------------------------------------------------
If you have questions or comments and would like to reach us directly, please feel free to do
so at the following outlets. We love hearing from developers!

Email: ryan [at] mygengo dot com  
Twitter: **[@mygengo_dev](http://twitter.com/mygengo_dev)**  

If you come across any issues, please file them on the **[Github project issue tracker](https://github.com/myGengo/mygengo-csharp/issues)**. Thanks!
