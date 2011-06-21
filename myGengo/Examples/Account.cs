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
